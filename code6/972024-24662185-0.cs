     private void BackgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
	   string S = Convert.ToString(e.UserState);
	   Label1.Text = S;
	   ProgressBar1.PerformStep();
	   S = null;
    }
     Private Sub BackgroundWorker2_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BackgroundWorker2.ProgressChanged
        Dim S As String = CType(e.UserState, String)
        Label1.Text = S
        ProgressBar1.PerformStep()
        S = Nothing
    End Sub
