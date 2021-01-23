    public Task Init(Type tableType)
    {
        try
        {
            this.initialized = true;
            const string Path = "syncorder.db";
            var store = new MobileServiceSQLiteStore(Path);
            MethodInfo myDefineTable = RuntimeReflectionExtensions.GetRuntimeMethod(typeof(MobileServiceSQLiteStoreExtensions), "DefineTable", new Type[] { typeof(MobileServiceSQLiteStore) });
            myDefineTable = myDefineTable.MakeGenericMethod(tableType);
            myDefineTable.Invoke(null, new object[] { store });
        for the parameters to pass into the method
        }
        catch (Exception ex)
        {
            this.initialized = false;
            throw ex;
        }
    }
