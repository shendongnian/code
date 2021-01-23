        Private Sub StartButton_Click(sender As Object, e As RoutedEventArgs) Handles StartButton.Click
        Dim MyFirstName As String
        Dim MyLastName As String
        OutputText.Text = ""
        OutputText.AppendText("What is your first name?" + vbCrLf)
        MyFirstName = InputBox("")
        OutputText.AppendText("And what is your last name?" + vbCrLf)
        MyLastName = InputBox("")
        OutputText.AppendText("Hello " + MyFirstName + " " + MyLastName + "!" + vbCrLf)
    End Sub
