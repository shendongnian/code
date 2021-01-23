    private SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);
    public async Task ServerDataChangedAsync(int i)
    {
        Debug.WriteLine("WaitAsync {0}", i);
        await _semaphore.WaitAsync();
        try
        {
            await Task.Factory.StartNew(async () =>
            {
                await UpdateUI(i);
            }, CancellationToken.None, TaskCreationOptions.None, _scheduler).Unwrap();
        }
        finally 
        {
            _semaphore.Release();
            Debug.WriteLine("Release {0}", i);
        }
    }
