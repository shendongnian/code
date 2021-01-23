    public static async Task TimeoutAfter(this Task task, TimeSpan timeSpan)
    {
        using(var cts = new CancellationTokenSource())
        {
            if (task.IsCompleted || timeSpan == Timeout.InfiniteTimeSpan)
            {
                await task;
                return;
            }
            if (timeSpan == TimeSpan.Zero)
                throw new TimeoutException();
            if (task == await Task.WhenAny(task, Task.Delay(timeSpan, cts.Token)))
            {
                cts.Cancel();
                await task;
            }
            else
            {
                throw new TimeoutException();
            }
        }
    }
