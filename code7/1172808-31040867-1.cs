    IEnumerable<TResult> AllMatching<TResult>(
    Expression<Func<TEntity, TResult>> columns,
    Expression<Func<TEntity, bool>> filter = null,
    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
    IList<Expression<Func<TEntity, object>>> includes = null,
    int? pageIndex = null,
    int? pageCount = null)
    {
      var query=Select(filter,orderby,includes,page,pageSize);
      return  query.Select(columns);
          
    }
