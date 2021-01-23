    public static Task RetryAsync(Func<bool> retryFunc, TimeSpan retryInterval)
    {
        return RetryAsync(retryFunc, retryInterval, CancellationToken.None);
    }
    public static Task RetryAsync(Func<bool> retryFunc, TimeSpan retryInterval, CancellationToken cancellationToken)
    {
        var tcs = new TaskCompletionSource<object>();
        
        cancellationToken.Register(() => tcs.TrySetCanceled());
        var timer = new Timer((state) =>
        {
            var taskCompletionSource = (TaskCompletionSource<object>) state;
            try
            {                   
                if (retryFunc())
                {
                    taskCompletionSource.TrySetResult(null);
                }
            }
            catch (Exception ex)
            {
                taskCompletionSource.TrySetException(ex);
            }
        }, tcs, TimeSpan.FromMilliseconds(0), retryInterval);
        // Once the task is complete, dispose of the timer so it doesn't keep firing. Also captures the timer
        // in a closure so it does not get disposed.
        tcs.Task.ContinueWith(t => timer.Dispose(),
                              CancellationToken.None,
                              TaskContinuationOptions.ExecuteSynchronously,
                              TaskScheduler.Default);
        return tcs.Task;
    }
        
