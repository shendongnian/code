    public virtual TEntity GetById<TEntity>(int id, Func<IQueryable<TEntity>, IQueryable<TEntity>> func) 
    {
        DbSet<TEntity> result = this.Set<TEntity>();
        IQueryable<TEntity> resultWithEagerLoading = func(result);
        return resultWithEagerLoading.FirstOrDefault(e => e.Id == id);
    }
