    public virtual async Task<int> AddAsync<T>(T entity)
    {
        SetLogContext(entity, _logctx);
        dbSet.Add(entity);
        if (isAutonomous)
        {
            return await ctx.SaveChangesAsync();
        }
        return 1;
    }
