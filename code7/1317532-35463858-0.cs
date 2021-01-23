    async Task Schedule(Action action, 
                        DateTime startTime, 
                        TimeSpan interval,
                        CancellationToken cancellationToken = default(CancellationToken))
    {
    	if(cancellationToken.IsCancellationRequested)
    	{
    		throw new TaskCanceledException();
    	}
    	var now = DateTime.UtcNow;
    	if(now < startTime)
    	{
    		await Task.Delay(startTime - now, cancellationToken);
            await Schedule(action, startTime, interval);
            return;
    	}
    	action();
    	var nextTime = startTime+interval;
    	await Schedule(action, nextTime, interval);
    }
