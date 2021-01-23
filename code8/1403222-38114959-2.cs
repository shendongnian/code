    public static IEfBulkInsertProvider Get(DbContext context)
    {
        var connectionTypeName = context.Database.Connection.GetType().FullName;
        if (!Providers.ContainsKey(connectionTypeName))
        {
            throw new BulkInsertProviderNotFoundException(connectionTypeName);
        }
        return Providers[connectionTypeName]().SetContext(context);
    }
