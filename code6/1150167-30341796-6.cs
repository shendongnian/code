    private void MyProcess(CancellationTokenSource cts)
    {
      	cts.Token.ThrowIfCancellationRequested(); 
    	
    	// Move the heavy work to a different process
    	var process = Process.Start(new ProcessStartInfo { /*  */ });
        // Register to the cancellation, where if the process is still
        // running, kill it.
    	cts.Token.Register(() => 
    	{
    		if (!process.HasExited)
    		{
    			process.Kill();
    		}
    	});
    }
