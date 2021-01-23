    public async Task DoWorkAsync()
    {
        // Let's assume we're on the UI thread now.
        // Dummy up some items to process.
        List<object> items = GetItemsToProcess();
        // Wire up progress reporting.
        // Creating a new instance of Progress
        // will capture the SynchronizationContext
        // any any calls to IProgress.Report
        // will be posted to that context.
        Progress<int> progress = new Progress<int>();
        progress.ProgressChanged += (sender, progressPercentage) =>
        {
            // This callback will run on the thread which
            // created the Progress<int> instance.
            // You can update your UI here.
            this.ProgressBar.Value = progressPercentage;
        };
        await Task.Run(() => this.LongRunningCpuBoundOperation(items, progress));
    }
    private void LongRunningCpuBoundOperation(List<object> items, IProgress<int> progress)
    {
        int doneSoFar = 0;
        int lastReportedProgress = -1;
        foreach (var item in items)
        {
            // Process item.
            Thread.Sleep(1);
            // Calculate and report progress.
            doneSoFar++;
            var progressPercentage = (int)((double)doneSoFar / items.Count * 100);
            // Only post back to the dispatcher SynchronizationContext
            // if the progress percentage actually changed.
            if (progressPercentage != lastReportedProgress)
            {
                // Note that progress is IProgress<int>,
                // not Progress<int>. This is important
                // because Progress<int> implements
                // IProgress<int>.Report explicitly.
                progress.Report(progressPercentage);
                lastReportedProgress = progressPercentage;
            }
        }
    }
