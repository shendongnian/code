    Public Class Form1
        Private Sub Form1_Click(sender As Object, e As EventArgs) Handles Me.Click
            Dim wdApp As New Microsoft.Office.Interop.Word.Application()
            Dim wdDoc As Microsoft.Office.Interop.Word.Document
            wdDoc = wdApp.Documents.Open("C:\SO\Abc.docm")
            Dim s As String = wdApp.Run("myFunc", "Hello World!")
            MsgBox(s)
            wdDoc.Close(False) : wdApp.Quit()
        End Sub
    End Class
