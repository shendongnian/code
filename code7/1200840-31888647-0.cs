    private void backGroundWrkr_DoWork(object sender, DoWorkEventArgs e)
    {
        DataTable dtInstant = new DataTable();
        for (int i = 0; i < allFiles.Count; i++)
        {
            if (backGroundWrkr.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
               myApp.processFile(allFiles[i]);
              this.Invoke((MethodInvoker)delegate
              {
               myGrdVw.DataSource = myApp.dtResults.copy();
              });
            backGroundWrkr.ReportProgress(100 * (i + 1) / allFiles.Count);
        }
        backGroundWrkr.ReportProgress(100);
    }
