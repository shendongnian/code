    public static Task RunViaQueueBackgroundWorkItem(Func<CancellationToken,Task> asyncAction)
    {
        TaskCompletionSource<int> tcs = new TaskCompletionSource<int>();
        HostingEnvironment.QueueBackgroundWorkItem(async (ct) => 
        {
            try
            {
                await asyncAction(ct);
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
