    public static Task WhenAll(
        IEnumerable<Task> tasks,
        CancellationToken cancellationToken,
        int millisecondsTimeOut)
    {
        var cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        cancellationTokenSource.CancelAfter(millisecondsTimeOut);
            
        return Task.WhenAll(tasks).ContinueWith(
            _ => _.GetAwaiter().GetResult(), 
            cancellationTokenSource.Token,
            TaskContinuationOptions.ExecuteSynchronously, 
            TaskScheduler.Default);
    }
