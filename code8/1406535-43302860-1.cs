    public static Task Delay(TimeSpan delay, CancellationToken cancelToken)
    {
        // Possible optimizations
        if (cancelToken.IsCancellationRequested)
        {
            return Task.FromCanceled(cancelToken);
        }
        if (delay <= TimeSpan.Zero)
        {
            return Task.CompletedTask;
        }
        return _Delay(delay, cancelToken);
    }
    private static async Task _Delay(TimeSpan delay, CancellationToken cancelToken)
    {
        // Actual implementation
        TaskCompletionSource<bool> taskSource = new TaskCompletionSource<bool>();
        SleepAwareTimer timer = new SleepAwareTimer(
            o => taskSource.TrySetResult(true), null,
            TimeSpan.FromMilliseconds(-1), TimeSpan.FromMilliseconds(-1));
        IDisposable registration = cancelToken.Register(
            () => taskSource.TrySetCanceled(cancelToken), false);
        timer.Change(delay, TimeSpan.FromMilliseconds(-1));
        try
        {
            await taskSource.Task;
        }
        finally
        {
            timer.Dispose();
            registration.Dispose();
        }
    }
