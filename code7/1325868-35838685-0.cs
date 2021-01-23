    public CancellationTokenSource Add(Action<CancellationToken> action, Action<Task> callback, int timeoutInMilliseconds)
    {
        var cts = new CancellationTokenSource();
        Instance.StartNew(() =>
        {
            cts.CancelAfter(timeoutInMilliseconds);
            var task = Task.Factory.StartNew(() => action(cts.Token), cts.Token, TaskCreationOptions.AttachedToParent|TaskCreationOptions.LongRunning, TaskScheduler.Default);
            try
            {
                task.Wait(timeoutInMilliseconds, cts.Token);
            }
            catch (OperationCanceledException) { }
            callback(task);
        }, cts.Token);
        return cts;
    }
