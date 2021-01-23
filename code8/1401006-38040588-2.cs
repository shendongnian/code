    public static Task RunViaQueueBackgroundWorkItem(Action<CancellationToken> action)
    {
        TaskCompletionSource<int> tcs = new TaskCompletionSource<int>();
        HostingEnvironment.QueueBackgroundWorkItem((ct) =>
        {
            try
            {
                action(ct);
                if (ct.IsCancellationRequested)
                    tcs.TrySetCanceled();
                else
                    tcs.TrySetResult(0);
            }
            catch (Exception ex)
            {
                tcs.TrySetException(ex);
            }
        });
        return tcs.Task;
    }
