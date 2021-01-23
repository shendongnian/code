    Public Class Form1
        Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
            For I As Integer = 0 To 100
                BackgroundWorker1.ReportProgress(I)
                Threading.Thread.Sleep(25)
                If I = 50 Then Throw (New NullReferenceException)
            Next
        End Sub
        Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
            BackgroundWorker1.RunWorkerAsync()
        End Sub
        Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
            ProgressBar1.Value = e.ProgressPercentage
        End Sub
        Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
            ProgressBar1.Value = 0
        End Sub
    End Class
