    private void UpdateProgress()
    {
        double temp = double.Parse((produced * 100 / 10000000).ToString("0.00"));
        progress = temp;
        asyncOperation.Post(new SendOrPostCallback(delegate
        {
            if (ProgressChanged != null)
                ProgressChanged(this, EventArgs.Empty);
        }), null);
    }
