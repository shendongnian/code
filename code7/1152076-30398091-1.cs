    private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        bgWorker.ReportProgress(0, "Some message to display.");
    }
    private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        status.Content = e.UserState.ToString();
    }
