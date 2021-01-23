    private void btnOk_Click(object sender, EventArgs e)
    {
        progressBar.Visible = true;
        backgroundWorker.ReportsProgress = true;
        backgroundWorker.RunWorkerAsync();
    }
    private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        doALittleWork();
        backgroundWorker.ReportProgress(10, null);
        doMoreWork();
        backgroundWorker.ReportProgress(20, null);
        //...
        doLastWork();
        backgroundWorker.ReportProgress(100, null);
    }
    private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        progressBar.Visible = false;   
    }
    private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        progressBar.Value = e.ProgressPercentage;
    }
