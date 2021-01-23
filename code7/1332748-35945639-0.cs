    public Task Init(Type tableType)
    {
        try
        {
            this.initialized = true;
            const string Path = "syncorder.db";
            var store = new MobileServiceSQLiteStore(Path);
            MethodInfo myDefineTable = store.GetType().GetRuntimeMethod("DefineTable", null); // The null value can be replaced with an array of Types which would be the parameter types the method takes
            myDefineTable = myDefineTable.MakeGenericMethod(tableType);
            myDefineTable.Invoke(null, null); // The second null value is used for the parameters to pass into the method
        }
        catch (Exception ex)
        {
            this.initialized = false;
            throw ex;
        }
    }
