    // Arbitrary time to wait between checking on the running process and cancellation
    private const int DelayTimeInSeconds = 5000;
    private Task heavyProcess;
    private void MyProcess(CancellationTokenSource cts)
    {
        CancellationToken token = cts.Token;
    
        heavyProcess = Task.Run(async () =>
        {
            token.ThrowIfCancellationRequested();
    		
    		// Move the heavy work to a different process
    		var process = Process.Start(new ProcessStartInfo { /*  */ });
    		
    		while (!process.HasExited && !token.IsCancellationRequested)
    		{
    			await Task.Delay(DelayTimeInSeconds);
    		}
    	
    		// If cancellation was requested, kill the process and throw
    		if (token.IsCancellationRequested)
    		{
    			process.Kill();
    			token.ThrowIfCancellationRequested();
    		}
    		
        }, token);
    }
    
