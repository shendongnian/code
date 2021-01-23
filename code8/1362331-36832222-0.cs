    private IQueryable<TEntity> FilterQuery<TValue>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TValue>> sortExpression, OrderBy orderBy = OrderBy.Ascending)    
    {
        IQueryable<TEntity> entities = _dbEntitySet;         
        entities = (predicate != null) ? entities.Where(predicate) : entities;
        entities = (orderBy == OrderBy.Ascending) ? entities.OrderBy(sortExpression) : entities.OrderByDescending(sortExpression);
        return entities;
    }
