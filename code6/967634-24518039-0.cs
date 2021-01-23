    public virtual int InsertWithReturnId<TEntity>(TEntity entity)
        where TEntity : IIdentity
    {
        dbSet.Add(entity);
        //save changes()?
        return entity.Id;
    }
