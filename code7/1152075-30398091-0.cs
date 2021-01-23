    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        backgroundWorker1.ReportProgress(0, "Some message to display.");
    }
    private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        status.Content = e.UserState.ToString();
    }
