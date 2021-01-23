    private void UpdateProgressbar(int percentage)
    {
        if (InvokeRequired)
        {
            this.BeginInvoke(new Action<int>(UpdateProgressbar), new object[] { percentage });
            return;
        }
    
        pb.Value = percentage;
    }
    
    private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        UpdateProgressbar(e.ProgressPercentage);           
    }
