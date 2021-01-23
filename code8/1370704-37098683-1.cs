    private object updateProgressLock = new object();
    private bool updateProgressRequest = false;
    private void UpdateProgress()
    {
        double temp = double.Parse((produced * 100 / 10000000).ToString("0.00"));
        if (progress == temp) return; // (1)
        progress = temp;
        if (ProgressChanged == null) return; // (2)
        lock (updateRequestLock)
        {
            if (updateRequest) return; // (3)
            asyncOperation.Post(new SendOrPostCallback(delegate
            {
                lock (updateRequestLock)
                    updateRequest = false; 
                if (ProgressChanged != null)
                    ProgressChanged(this, EventArgs.Empty);
            }), null);
            updateRequest = true;
        }
    }
  
