    public virtual void InsertOrUpdate(TE entity)
    {
        var entitySet = _context.Set<TE>();
        if(entity.Id.Equals(default(int))){
            entitySet .Add(entity);
            return;
        }
        entitySet.Update(entity);
    }
