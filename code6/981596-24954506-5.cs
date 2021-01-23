    private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
    {
    if (InvokeRequired)
    {
      BeginInvoke(new Action(() => backgroundWorker1_ProgressChanged(sender, e)));
    }
    else
    {
      if (progressBarX1.Value != e.ProgressPercentage)
      {
        progressBarX1.Value = e.ProgressPercentage;
        progressBarX1.Refresh();
      }
    }
