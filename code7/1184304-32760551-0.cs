        Func<IQueryable<Entity>, IOrderedQueryable<Entity>> orderBy = query => query.OrderBy(e => e.ID);
        
                    Expression<Func<Entity, bool>> fitler = e => e.Active;  
    
    
    public virtual IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
                {
                    IQueryable<T> query = dbSet;
        
                    if (filter != null)
                        query = query.Where(filter);
        
                    if (orderBy != null)
                        return orderBy(query).ToList();
                    else
                        return query.ToList();
                }
