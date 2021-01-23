    public virtual void Delete(T entity)
            {
                if (entity == null) throw new ArgumentNullException(typeof(T) + " cannot be null.");
    
    
                try
                {
                    DbEntityEntry dbEntityEntry = _DbContext.Entry(entity);
                    if (dbEntityEntry.State != EntityState.Deleted)
                    {
                        dbEntityEntry.State = EntityState.Deleted;
                    }
                    else
                    {
                        _DbSet.Attach(entity);
                        _DbSet.Remove(entity);
                    }
                }
                catch (Exception ex)
                {
                        throw;
                }
    
            }
