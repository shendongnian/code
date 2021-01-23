    private int ProgressPercentage { get; set; }
    private void DoWork()
    {
        Parallel.For(1, max, i =>
        {
            lock (lockObject)
            {
                numbersList.Add("Hello World! [" + i + "]");
            }
            int progressPercentage = Convert.ToInt32((double)i / max * 100);
            // Only report progress when it changes
            if (progressPercentage != oldProgress)
            {
                Interlocked.Exchange(ProgressPercentage, progressPercentage);
                ShowProgress();
            }
        });
    }
    private void ShowProgress()
    {
        pb.Value = ProgressPercentage;
    }
