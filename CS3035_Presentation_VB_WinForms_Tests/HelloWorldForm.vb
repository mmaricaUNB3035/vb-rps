Imports System.Windows.Forms

Public Class HelloWorldForm
    Inherits Form

    Private opponentMove, loseLabel, rockBtn, paperBtn, scissorBtn, yourMove

    Sub New() ' constructor

        Dim titleLabel As New Label()
        titleLabel.Text = "ROCK PAPER SCISSORS"
        titleLabel.Font = New Font("Arial", 16, FontStyle.Bold)
        titleLabel.Width = Me.ClientSize.Width
        titleLabel.TextAlign = ContentAlignment.MiddleCenter
        titleLabel.Margin = New Padding(
            (Me.ClientSize.Width - titleLabel.Width) / 2,
            10,
            titleLabel.Margin.Right,
            20
        )

        Dim yourMoveLabel As New Label
        yourMoveLabel.Text = "Your move"
        yourMoveLabel.TextAlign = ContentAlignment.MiddleCenter
        yourMoveLabel.Font = New Font("Arial", 12, FontStyle.Regular)


        Dim rockBtn As New Button
        rockBtn.Text = "☁"
        rockBtn.Font = New Font("MS UI Gothic", 16, FontStyle.Bold)
        rockBtn.Width = 50
        rockBtn.Height = 50
        Me.rockBtn = rockBtn
        AddHandler rockBtn.Click, AddressOf RockClick

        Dim paperBtn As New Button
        paperBtn.Text = "🗋"
        paperBtn.Font = New Font("Arial", 24, FontStyle.Bold)
        paperBtn.Width = 50
        paperBtn.Height = 50
        Me.paperBtn = paperBtn
        AddHandler paperBtn.Click, AddressOf PaperClick

        Dim scissorBtn As New Button
        scissorBtn.Text = "✄"
        scissorBtn.Font = New Font("Arial", 16, FontStyle.Bold)
        scissorBtn.Width = 50
        scissorBtn.Height = 50
        Me.scissorBtn = scissorBtn
        AddHandler scissorBtn.Click, AddressOf ScissorClick


        Dim buttonPanel As New FlowLayoutPanel
        buttonPanel.Controls.AddRange({rockBtn, paperBtn, scissorBtn})
        buttonPanel.FlowDirection = FlowDirection.TopDown
        buttonPanel.WrapContents = False
        buttonPanel.AutoSize = True
        buttonPanel.Margin = New Padding(
            20,
            buttonPanel.Margin.Top,
            buttonPanel.Margin.Right,
            buttonPanel.Margin.Bottom
        )

        Dim leftPanel As New FlowLayoutPanel
        leftPanel.Controls.AddRange({yourMoveLabel, buttonPanel})
        leftPanel.FlowDirection = FlowDirection.TopDown
        leftPanel.WrapContents = False
        leftPanel.AutoSize = True

        Dim opponentLabel As New Label
        opponentLabel.Text = "Computer's move"
        opponentLabel.Width = 150
        opponentLabel.TextAlign = ContentAlignment.MiddleCenter
        opponentLabel.Font = New Font("Arial", 12, FontStyle.Regular)


        Dim opponentMove As New Label()
        opponentMove.Text = ""
        opponentMove.AutoSize = True
        opponentMove.Font = New Font("MS UI Gothic", 50, FontStyle.Bold)
        opponentMove.TextAlign = ContentAlignment.MiddleCenter
        opponentMove.Width = 50
        Me.opponentMove = opponentMove
        opponentMove.Margin = New Padding(
            25,
            20,
            opponentMove.Margin.Right,
            opponentMove.Margin.Bottom
        )

        Dim loseLabel As New Label()
        loseLabel.Text = "YOU LOSE"
        loseLabel.AutoSize = True
        loseLabel.Font = New Font("MS UI Gothic", 15, FontStyle.Bold)
        loseLabel.TextAlign = ContentAlignment.MiddleCenter
        loseLabel.Width = 50
        loseLabel.Visible = False
        Me.loseLabel = loseLabel
        loseLabel.Margin = New Padding(
            25,
            loseLabel.Margin.Top,
            loseLabel.Margin.Right,
            loseLabel.Margin.Bottom
        )

        Dim rightPanel As New FlowLayoutPanel
        rightPanel.Controls.AddRange({opponentLabel, opponentMove, loseLabel})
        rightPanel.FlowDirection = FlowDirection.TopDown
        rightPanel.WrapContents = False
        rightPanel.AutoSize = True


        Dim mainPanel As New FlowLayoutPanel
        mainPanel.Controls.AddRange({titleLabel, leftPanel, rightPanel})
        mainPanel.FlowDirection = FlowDirection.LeftToRight
        mainPanel.Dock = DockStyle.Fill

        Me.Controls.Add(mainPanel)

    End Sub

    Private Sub RockClick()
        yourMove = 1
        Lose()
    End Sub

    Private Sub PaperClick()
        yourMove = 2
        Lose()
    End Sub
    Private Sub ScissorClick()
        yourMove = 3
        Lose()
    End Sub
    Private Sub Lose()

        Dim i = Int((Rnd() * 3) + 1)



        If yourMove = 1 Then ' computer rock
            If i = 1 Then
                opponentMove.Text = "☁"
                loseLabel.Text = "Draw..."
            ElseIf i = 2 Then
                opponentMove.Text = "🗋"
                loseLabel.Text = "YOU LOSE"
            Else
                opponentMove.Text = "✄"
                loseLabel.Text = "YOU WIN"
            End If
        ElseIf yourMove = 2 Then
            If i = 1 Then
                opponentMove.Text = "☁"
                loseLabel.Text = "YOU WIN"
            ElseIf i = 2 Then
                opponentMove.Text = "🗋"
                loseLabel.Text = "Draw..."
            Else
                opponentMove.Text = "✄"
                loseLabel.Text = "YOU LOSE"
            End If
        Else
            If i = 1 Then
                opponentMove.Text = "☁"
                loseLabel.Text = "YOU LOSE"
            ElseIf i = 2 Then
                opponentMove.Text = "🗋"
                loseLabel.Text = "YOU WIN"
            Else
                opponentMove.Text = "✄"
                loseLabel.Text = "Draw..."
            End If
        End If

        loseLabel.Visible = True


    End Sub

    Shared Sub Main() ' entry point
        Application.Run(New HelloWorldForm())
    End Sub
End Class
