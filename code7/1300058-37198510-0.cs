    Imports SKYPE4COMLib
    Public Class Form1
    Dim skype As Skype
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        For Each r As Chat In skype.Chats
            'If topic = "", then it is an individual chat
            If r.Topic <> "" Then
                RichTextBox1.AppendText(r.Topic & vbCrLf)
            Else
                'If topic = "", then display the FriendlyName instead (individual chat)
                RichTextBox1.AppendText(r.FriendlyName & vbCrLf)
            End If
        Next
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        skype = New Skype()
        skype.Attach(7, True)
    End Sub
    End Class
