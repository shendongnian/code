    private readonly Dictionary<string, AsyncLock> _mutexes = new Dictionary<string, AsyncLock>();
    private GetMutex(string key) {
        lock (_mutexes) {
            if (_mutexes.ContainsKey(key)) return _mutexes[key];
            // no mutex yet, create a new one
            AsyncLock mutex = new AsyncLock();
            _mutexes.Add(key, mutex);
            return mutex;
        }
    }
    ....
    protected async Task Process(Message msg) {
        using (await GetMutex(message.Key).LockAsync()) {
            ...
        }
    }
