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
    private void doSomeWork()
    {
      //do what you want here..
      backgroundWorker.ReportProgress(yourprogresspercentagenumber);
      //do what you want again..
      backgroundWorker.ReportProgress(yourprogresspercentagenumber);
    }
