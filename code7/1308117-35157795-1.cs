    async Task RunActionPeriodicallyAsync(Action action, 
                               TimeSpan ts, 
                               CancellationToken token = default(CancellationToken))
    {
        while(!token.IsCancellationRequested)
        {
            action();
            await Task.Delay(ts, token);
        }
    }
