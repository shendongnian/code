    public IMobileServiceSyncTable<T> DefineTable<T>()
    {
        var store = new MobileServiceSQLiteStore(DatabaseName);
        store.DefineTable<T>();
        var Client = Client = new MobileServiceClient(SystemOptions.AzureStorage);
        Client.SyncContext.InitializeAsync(store);
        return Client.GetSyncTable<T>();
    }
