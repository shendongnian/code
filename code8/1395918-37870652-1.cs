    private SemaphoreSlim someLock = new SemaphoreSlim(1);
    public async Task TryToBeginSomeProcess()
    {
        try
        {
            await someLock.WaitAsync()
            await DoSomethingButOnlyOneAtATime();
        }
        finally
        {
            someLock.Release();
        }
    }
    public async Task DoSomethingButOnlyOneAtATime()
    {
        // do some work
    
        await SomeWork();
    
        // do some more work
    }
