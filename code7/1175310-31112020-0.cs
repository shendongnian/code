    public Task ContinueWith(Action<Task> continuationAction)
    {
        StackCrawlMark stackMark = StackCrawlMark.LookForMyCaller;
        return ContinueWith(continuationAction, 
                            TaskScheduler.Current, 
                            default(CancellationToken),
                            TaskContinuationOptions.None, ref stackMark);
    }
 
