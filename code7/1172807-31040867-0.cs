     public IQueryable<TEntity> Select(
     Expression<Func<TEntity, bool>> filter = null,
     Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
     IList<Expression<Func<TEntity, object>>> includes = null,
     int? page = null,
     int? pageSize = null)
     {
            IQueryable<TEntity> query = _dbSet;
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            if (filter != null)
            {
                query = query.AsExpandable().Where(filter);
            }
            if (page != null && pageSize != null)
            {
                query = query.Skip((page.Value - 1)*pageSize.Value).Take(pageSize.Value);
            }
            return query;
     }
