    public IList<T> GetEntityList<T>(Expression<Func<T, bool>> whereExpression, Expression<Func<T, object>> orderByExpression, ListSortDirection orderDirection, int totalPages, int start, int limit)
    {
        IList<T> returnVar;
        using (var session = _nhibernate.OpenSession())
        {
            var firstQueryable = session.Query<T>().Where(whereExpression);
            IQueryable<T> secondQueryable = orderDirection == ListSortDirection.Ascending ? firstQueryable.OrderBy(orderByExpression) : firstQueryable.OrderByDescending(orderByExpression);
            returnVar = totalPages > 0 ? secondQueryable.Skip(start).Take(limit).ToList() : secondQueryable.ToList();    
        }
        return returnVar;
    }
