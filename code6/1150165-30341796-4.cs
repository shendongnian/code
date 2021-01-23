    // Arbitrary time to wait between checking on the running process and cancellation
    private const int DelayTimeInSeconds = 5000;
    private Task heavyProcess;
    private void MyProcess(CancellationTokenSource cts)
    {
        CancellationToken token = cts.Token;
    
        heavyProcess = Task.Run(() =>
        {
            token.ThrowIfCancellationRequested();
    		
    		// Move the heavy work to a different process
    		var process = Process.Start(new ProcessStartInfo { /*  */ });
    		
		    token.Register(() => 
		    {
			   if (!process.HasExited)
			   {
				   process.Kill();
			   }
			
			   // This is optional, you may decide to throw a OCE or run the task
			   // to it's completion, depends on your needs
			   token.ThrowIfCancellationRequested();
		    }, false);
        }, token);
    }
    
