    private void Initializer()
    {
        var store = InitLocalStore();
        InitSyncContext(store); // <-- Here without await call
        ...
    }
    
    // Here is void but with a async call inside
    private async void InitSyncContext(MobileServiceSQLiteStore store)
    {
        await Client.SyncContext.InitializeAsync(store);
    }
