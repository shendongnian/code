    public TEntity GetById<TEntity>(int id)
        where TEntity : class
    {
        return _myDbContext.Set<TEntity>().Where(x => x.Id == id).FirstOrDefault();
    }
