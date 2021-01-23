    public async Task AddContent(IBar bar)
    {
        var cancel = new CancellationTokenSource();
        await bar.GetStringsAsync()
                 .ContinueWith(task => MyCollection.AddRange(task.Result),
                               cancel,
                               TaskContinuationOptions.NotOnCancel,
                               TaskScheduler.FromCurrentSynchronizationContext());
    }
