    public virtual void Delete(object id)
    {
         TEntity entity = dbSet.Find(id);
    
         if (context.Entry(entity).State == EntityState.Detached)
              dbSet.Attach(entity);
    
         dbSet.Remove(entity);
         context.SaveChanges();
    
    }
