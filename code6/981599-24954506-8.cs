    private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
    {
      if (InvokeRequired)
      {
        BeginInvoke(new Action(() => backgroundWorker1_ProgressChanged(sender, e)));
      }
      else
      {
        progressBarX1.Value = e.ProgressPercentage;
      }
    }
