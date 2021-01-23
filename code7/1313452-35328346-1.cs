    Public Class Form1
        Private ExceptionLogFile As String = ""
        Public Sub New()
            InitializeComponent()
            My.Application.UnhandledExceptionsFileName = "unHandledExceptions.xml"
            ExceptionLogFile = My.Application.UnhandledExceptionsFileName
        End Sub
        Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
            If My.Application.RunningUnderDebugger Then
                MessageBox.Show("Please execute from Window's Explorer")
                Application.ExitThread()
            End If
        End Sub
    
        Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
            Throw New Exception("Hey")
        End Sub
    End Class
