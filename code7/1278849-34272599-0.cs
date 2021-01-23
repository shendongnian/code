    public void AddContent(IBar bar)
    {
        var cancel = new CancellationTokenSource();
        var result = bar.GetStringsAsync().ContinueWith(
            task => task.Result,
            cancel,
            TaskContinuationOptions.NotOnCancel,
            TaskScheduler.FromCurrentSynchronizationContext());
       MyCollection.AddRange(result.Result);
    }
