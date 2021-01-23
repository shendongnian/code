    Task.Factory.StartNew(() =>
    {
        // Do background work.
    }).ContinueWith(_ =>
    {
        // Update UI, then spawn child task to do more background work...
        Task.Factory.StartNew(() =>
        {
            // ...but child task runs on UI thread!
        });
    },
        CancellationToken.None,
        TaskContinuationOptions.None,
        TaskScheduler.FromCurrentSynchronizationContext());
