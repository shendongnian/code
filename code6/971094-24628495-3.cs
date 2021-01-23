    public void bw_DoWork(object sender, DoWorkEventArgs e)
    {
          BackgroundWorker worker = sender as BackgroundWorker;
    
          if ((worker.CancellationPending == true))
          {
             e.Cancel = true;
          }
          else
          {
          for (int x = 0; x < 1000; x++)
          {
             System.Threading.Thread.Sleep(10);
             worker.ReportProgress(x);
          }
       }
    }
