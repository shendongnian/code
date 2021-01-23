    public virtual void Update(T entity)
            {
                DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
                
                if (dbEntityEntry.State == EntityState.Detached)
                {
                    var pkey = _dbset.Create().GetType().GetProperty("Id").GetValue(entity);//assuming Id is the key column
                    var set = DbContext.Set<T>();
                    T attachedEntity = set.Find(pkey);
                    if (attachedEntity != null)
                    {
                        var attachedEntry = DbContext.Entry(attachedEntity);
                        attachedEntry.CurrentValues.SetValues(entity);
                    }                    
                }                
            }
