    public async Task TestAsync()
    {
        using (await _connectMutex.LockAsync())
        using (await _connectMutex.LockAsync())
    }
