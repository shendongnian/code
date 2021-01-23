    public static DbContext GetContext<TEntity>(this DbSet<TEntity> set)
        where TEntity : class
    {
        object internalSet = set.GetType()
            .GetField("_internalSet", BindingFlags.NonPublic | BindingFlags.Instance)
            .GetValue(set);
        object internalContext = internalSet.GetType().BaseType
            .GetField("_internalContext", BindingFlags.NonPublic | BindingFlags.Instance)
            .GetValue(internalSet);
        return (DbContext)internalContext.GetType()
            .GetProperty("Owner", BindingFlags.Instance | BindingFlags.Public)
            .GetValue(internalContext, null);
    }
    
