    public static Int32 GenerateId<TEntity>(this DbSet<TEntity> dbSet, string name) 
        where TEntity : class, INWatchStandardEntity
    {
        NWatchObjectType objectType = Common.ToObjectType(dbSet.GetType());
        return Common.GetObjectIdFromName(objectType, name);
    }
