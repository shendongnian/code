    private IQueryable<T> ApplyFilter<T>(
              IQueryable<T> qry,
              Expression<Func<T,String>> field,
              String likeFilter)
    {
      var methodInfo = typeof(String).GetMethod("Contains");
      var methodCallExpression = Expression
        .Call(field.Body, methodInfo, Expression.Constant(likeFilter));
      var predicate = Expression
        .Lambda<Func<T, Boolean>>(methodCallExpression, field.Parameters[0]);
      return qry.Where(predicate);
    }
