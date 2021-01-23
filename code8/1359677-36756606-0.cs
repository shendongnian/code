    public async Task Run ()
    {
        isRunning = true;
        tokenSource = new CancellationTokenSource();
        token = tokenSource.Token;
        if (async)
            myTask = Do_CPU_Intensive_Job();
        else
            Do_CPU_Intensive_Job().Wait(token);      
    }
