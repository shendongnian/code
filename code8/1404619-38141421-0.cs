    private void btnOk_Click(object sender, EventArgs e)
    {
        timer.Start();
        progressBar.Visible = true;
        backgroundWorker.ReportsProgress = true;
        backgroundWorker.RunWorkerAsync();
    }
    
    private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        doSomeWork();
    }
