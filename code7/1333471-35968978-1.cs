    private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
      if (!backgroundWorker1.CancellationPending)
      {
        int pageCount = CalculatePageCount();
        backgroundWorker1.ReportProgress(-1, pageCount); 
        for (var pageNumber = 1; pageNumber <= pageCount; pageNumber++)
           ..... 
      }
    }
    
    private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      // First call, the percentage is negative to signal that UserState
      // contains the number of pages we loop on....
      if(e.ProgressPercentage == -1)
         progressBar1.Maximum = Convert.ToInt32(e.UserState);
      else
         progressBar1.Value = e.ProgressPercentage;
    }
