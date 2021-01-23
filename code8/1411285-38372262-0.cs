    private async void Initializer()
    {
        var store = InitLocalStore();
        await InitSyncContext(store); // <-- Here, await call
        ...
    }
    
    // Here returns Task (without having a return inside. No compile errors)
    private async Task InitSyncContext(MobileServiceSQLiteStore store)
    {
        await Client.SyncContext.InitializeAsync(store);
    }
