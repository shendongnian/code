    public static IQueryable<T> ResolveCriteria<T>(this IQueryable<T> query, GenericCriteria<T> criteria)
    {
      query = query.Where(criteria.Where);
      var t = criteria.OrderBy;
      var b = t.Body;
      if (b.NodeType == ExpressionType.Convert &&
          ((UnaryExpression)b).Type == typeof(Object)) {
        // Handle simple types, such as short, int, long, etc.
        var bb = ((UnaryExpression)b).Operand;
        var tt = Expression.Lambda(bb, t.Parameters);
        if (bb.Type == typeof(short))
          query = query.OrderBy((Expression<Func<T, short>>)tt);
        else if (bb.Type == typeof(int))
          query = query.OrderBy((Expression<Func<T, int>>)tt);
        else if (...)
          ...
      } else
        // Handle non-simple types, such as string.
        query = query.OrderBy(t);
      return query;
    }
