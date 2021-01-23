    private async Task InitializerAsync()
    {
        var store = InitLocalStore();
        await InitSyncContextAsync(store);
        ...
    }
    
    // Simply return the task that represents the async operation and let the caller await it
    private Task InitSyncContextAsync(MobileServiceSQLiteStore store)
    {
        return Client.SyncContext.InitializeAsync(store);
    }
