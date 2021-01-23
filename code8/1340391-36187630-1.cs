    private readonly Dictionary<string, AsyncLock> _mutexes = new Dictionary<string, AsyncLock>();
    private GetMutex(string key)
    {
        lock (_mutexes)
        {
            AsyncLock mutex;
            if (!_mutexes.TryGetValue(key, out mutex))
            {
                // no mutex yet, create a new one
                mutex = new AsyncLock();
                _mutexes.Add(key, mutex);
            }
            return mutex;
        }
    }
    ....
    protected async Task Process(Message msg)
    {
        using (await GetMutex(msg.Key).LockAsync())
        {
            ...
        }
    }
