    public static async Task<ProcessMessageReturn> RenewLockAfter(this Task<ProcessMessageReturn> processTask, BrokeredMessage message, int maxDuration)
    {
        var ss = new SemaphoreSlim(2);
        var startTime = DateTime.UtcNow;
        var trackedTasks = new List<Task> {processTask};
        var timeoutCancellationTokenSource = new CancellationTokenSource();
        while (true)
        {
            ss.Wait(timeoutCancellationTokenSource.Token);
            if (startTime.AddMinutes(maxDuration) < DateTime.UtcNow)
            {
                var task = Task.Run(async () =>
                {
                    await Task.Delay(TimeSpan.FromTicks(message.LockedUntilUtc.Ticks - DateTime.UtcNow.AddSeconds(30).Ticks), timeoutCancellationTokenSource.Token);
                    await message.RenewLockAsync();
                    ss.Release();
                }, timeoutCancellationTokenSource.Token);
                trackedTasks.Add(task);
            }
            var completedTask = await Task.WhenAny(trackedTasks);
            if (completedTask != processTask) continue;
            timeoutCancellationTokenSource.Cancel();
            return processTask.Result;
        }
        
    }
