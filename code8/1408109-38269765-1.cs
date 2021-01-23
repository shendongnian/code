    public virtual TDto Create(TDto data)
    {
        TEntity entity = ToEntity(data);
        DbEntityEntry<TEntity> dbEntity = Context.Entry<TEntity>(entity);
        // call UpdateReferences first...
        UpdateReferences(data, dbEntity);
        // ...then set the State to Added
        dbEntity.State = EntityState.Added;
        Context.SaveChanges();
        data = ToModel(dbEntity.Entity);
        return data;
    }
