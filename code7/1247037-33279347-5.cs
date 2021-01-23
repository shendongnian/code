    private static string GetKeyName<T>(DbContext db)
        where T : class
    {            
        ObjectContext objectContext = ((IObjectContextAdapter)db).ObjectContext;
        ObjectSet<T> objectSet = objectContext.CreateObjectSet<T>();
        var keyNames = objectSet.EntitySet.ElementType.KeyProperties
                                .Select(p => p.Name).ToArray();
        if (keyNames.Length > 1)
            throw new NotSupportedException("Composite keys not supported");
        return keyNames[0];
    }
