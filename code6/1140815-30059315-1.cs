    ParameterExpression pe = Expression.Parameter(typeof(Request), "Request");
    Expression property = Expression.Property(pe, specField);
    MethodInfo contains = typeof(string).GetMethod("Contains", new Type[] { typeof(string) });
    Expression containsFoo = Expression.Call(property, contains, searchTerm);
    MethodCallExpression where = Expression.Call(
        typeof(Queryable),
        "Where",
        new Type[] { _db.Requests.ElementType },
        _db.Requests.Expression,
        Expression.Lambda<Func<Request, bool>>(containsFoo, new ParameterExpression[] { pe }));
    IQueryable<Request> result = _db.Requests.Provider.CreateQuery<Request>(where);
    var list = result.ToList();
