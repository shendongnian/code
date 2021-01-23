    static IQueryable<TEntity> Select<TEntity>(this  IQueryable<TEntity> query, List<Expression<Func<TEntity, bool>>> filters = null,
                                               List<Expression<Func<TEntity, object>>> includes = null)
    {
       if (includes != null)
       {
          query = includes.Aggregate(query, (current, include) => current.Include(include));
       }
       if (filters != null)
       {
          query = filters.Aggregate(query, (current, filter) => current.Where(filter)); //at the end this is going to be translated to condition1 && condition2 ...
       }
       return query;
    }
