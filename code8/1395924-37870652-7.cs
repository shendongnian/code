    SemaphoreSlim someLock = new SemaphoreSlim(1);
    private volatile Task onlyOneTask;
    public async Task TryToBeginSomeProcess()
    {
        Task localCopy;
        try
        {
            await someLock.WaitAsync();
            if (onlyOneTask == null)
            {
                onlyOneTask = DoSomethingButOnlyOneAtATime().YeildImmedeatly();
            }
            localCopy = onlyOneTask;
        }
        finally
        {
            someLock.Release();
        }
        await localCopy.ConfigureAwait(false);
    }
    public async Task DoSomethingButOnlyOneAtATime()
    {
        //Do some sycronous work.
        await SomeWork().ConfigureAwait(false);
            
        onlyOneTask = null;
    }
    //elsewhere
    public static class ExtensionMethods
    {
        public static async Task YeildImmedeatly(this Task @this)
        {
            await Task.Yield();
            await @this.ConfigureAwait(false);
        }
        public static async Task<T> YeildImmedeatly<T>(this Task<T> @this)
        {
            await Task.Yield();
            return await @this.ConfigureAwait(false);
        }
    }
