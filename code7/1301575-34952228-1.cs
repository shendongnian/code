    public virtual TEntity GetById(int id)
    {
       return _db.Set<TEntity>().FirstOrDefault(c => c.Code == id);
    }
 
