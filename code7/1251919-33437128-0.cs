    public EntityType findById(params object[] keys)
    {
        log.LogDebugStart();
        log.LogDebug("id=" + keys.Aggregate((a, b) => a.ToString() + ", " + b.ToString()));
    
        EntityType data;
    
        using (ObjectContextWrapper contextWrapper = TransactionHelper.GetContextWrapper())
        {
            Entities bdd = contextWrapper.GetContext();
    
            DbSet<EntityType> set = bdd.Set<EntityType>();
    
            data = set.Find(keys);
        }
    
        log.LogDebugEnd();
        return data;
    }
