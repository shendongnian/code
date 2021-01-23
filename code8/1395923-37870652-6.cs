    private SemaphoreSlim someLock = new SemaphoreSlim(1);
    public async Task TryToBeginSomeProcess()
    {
        try
        {
            await someLock.WaitAsync();
            await DoSomethingButOnlyOneAtATime().ConfigureAwait(false);
        }
        finally
        {
            someLock.Release();
        }
    }
    public async Task DoSomethingButOnlyOneAtATime()
    {
        //Do some synchronous work.
        await SomeWork().ConfigureAwait(false);
        try
        {
            await someLock.WaitAsync().ConfigureAwait(false);
            onlyOneTask = null;
        }
        finally
        {
            someLock.Release();
        }
    }
