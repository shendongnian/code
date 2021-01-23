    public static Task Delay(TimeSpan delay)
    {
        return Delay(delay, CancellationToken.None);
    }
    public static async Task Delay(TimeSpan delay, CancellationToken cancelToken)
    {
        CancellationTokenSource localToken = new CancellationTokenSource(),
            linkedSource = CancellationTokenSource.CreateLinkedTokenSource(cancelToken, localToken.Token);
        DateTime delayExpires = DateTime.UtcNow + delay;
        PowerModeChangedEventHandler handler = (sender, e) =>
        {
            if (e.Mode == PowerModes.Resume)
            {
                CancellationTokenSource oldSource = localToken, oldLinked = linkedSource;
                localToken = new CancellationTokenSource();
                linkedSource = CancellationTokenSource.CreateLinkedTokenSource(cancelToken, localToken.Token);
                oldSource.Cancel();
                linkedSource.Dispose();
            }
        };
        SystemEvents.PowerModeChanged += handler;
        try
        {
            while (delay > TimeSpan.Zero)
            {
                try
                {
                    await Task.Delay(delay, linkedSource.Token);
                }
                catch (OperationCanceledException)
                {
                    cancelToken.ThrowIfCancellationRequested();
                }
                delay = delayExpires - DateTime.UtcNow;
            }
        }
        finally
        {
            linkedSource.Dispose();
            SystemEvents.PowerModeChanged -= handler;
        }
    }
