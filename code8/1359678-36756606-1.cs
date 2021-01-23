    public async Task Run ()
    {
        isRunning = true;
        tokenSource = new CancellationTokenSource();
        token = tokenSource.Token;
        myTask = Do_CPU_Intensive_Job();
        if (!async)
            myTask.Wait(token);    
    }
