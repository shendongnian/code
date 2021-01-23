    public virtual int InsertWithReturnId<TEntity>(TEntity entity)
        where TEntity : IIdentifier
    {
        dbSet.Add(entity);
        //save changes()?
        return entity.Id;
    }
