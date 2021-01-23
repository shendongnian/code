    private void WaitUntilLoadedAsync(Process p, Action callback, int timeout = 1500)
    {
        var thread_scheduler = TaskScheduler.FromCurrentSynchronizationContext();
    
        Task.Factory.StartNew(() => ProcessUtil.WaitUntilLoaded(p, timeout)).
            ContinueWith(t => callback.Invoke(), CancellationToken.None, TaskContinuationOptions.None,
                thread_scheduler);
    }
