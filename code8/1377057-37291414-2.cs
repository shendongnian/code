    public virtual T GetById<T>(int id,  params Expression<Func<T, object>>[] includeProperties) where T : BaseEntity<int>
        {
           var result = Context.Set<T>();
    
           IQueryable<T> query = null;
           foreach (var property in includeProperties)
           {
               query = query == null ? result.Include(property) : query.Include(property);
           }
    
          return query == null ? result.SingleOrDefault(t=>t.Id == id) :
                                  query.SingleOrDefault(t => t.Id == id);
    
        }
