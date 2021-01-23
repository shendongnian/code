    public TEntity GetById<TEntity>(int id)
        where TEntity : class
    {
        return Set<TEntity>().Where(x => x.Id == id).FirstOrDefault();
    }
