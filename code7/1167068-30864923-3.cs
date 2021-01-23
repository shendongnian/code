    private const int ConcurrencyLimit = 6;
    SemaphoreSlim semaphoreSlim = new SemaphoreSlim(ConcurrencyLimit);
    public async Task FooAsync()
    {
        var tasks = GetTasks();
        var sentTasks = tasks.Select(async task =>
        {
           await semaphoreSlim.WaitAsync();
           try
           {
              await ProcessEventAsync(await task);
           }
           finally
           {
               semaphoreSlim.Release();
           }
        });
        await Task.WhenAll(sentTasks);
    }
    private Task ProcessEventAsync(T someEvent) 
    {
        // Process event.
    }
