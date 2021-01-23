    System.Linq.Expressions.ParameterExpression pe = System.Linq.Expressions.Expression.Parameter(typeof(Request), "Request");
    System.Linq.Expressions.Expression property = System.Linq.Expressions.Expression.Property(pe, specField);
    MethodInfo contains = typeof(string).GetMethod("Contains", new Type[] { typeof(string) });
    System.Linq.Expressions.Expression containsFoo = Expression.Call(property, contains, searchTerm);
    System.Linq.Expressions.MethodCallExpression where = Expression.Call(
        typeof(Queryable),
        "Where",
        new Type[] { _db.Requests.ElementType },
        _db.Requests.Expression,
        System.Linq.Expressions.Expression.Lambda<Func<Request, bool>>(containsFoo, new System.Linq.Expressions.ParameterExpression[] { pe }));
    IQueryable<Request> result = _db.Requests.Provider.CreateQuery<Request>(where);
    var list = result.ToList();
