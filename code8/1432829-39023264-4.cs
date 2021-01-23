    public static async Task<T> TimeoutAfter<T>(this Task<T> task, TimeSpan timeSpan)
    {
        using(var cts = new CancellationTokenSource())
        {
            if (task.IsCompleted || timeSpan == Timeout.InfiniteTimeSpan)
            {
                return await task
            }
            if (timeSpan == TimeSpan.Zero)
                throw new TimeoutException();
            if (task == await Task.WhenAny(task, Task.Delay(timeSpan, cts.Token)))
            {
                cts.Cancel();
                return await task;
            }
            else
            {
                throw new TimeoutException();
            }
        }
    }
