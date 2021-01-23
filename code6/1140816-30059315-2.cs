    ParameterExpression pe = Expression.Parameter(typeof(Request), "Request");
    Expression property = Expression.Property(pe, specField);
    Expression predicate = null;
    if(searchType == "Fuzzy")
    {
        MethodInfo contains = typeof(string).GetMethod("Contains", new Type[] { typeof(string) });
        predicate = Expression.Call(property, contains, searchTerm);
    }
    else
    {
        predicate = Expression.Equal(property, Expression.Constant(searchTerm));
    }
    MethodCallExpression where = Expression.Call(
        typeof(Queryable),
        "Where",
        new Type[] { _db.Requests.ElementType },
        _db.Requests.Expression,
        Expression.Lambda<Func<Request, bool>>(predicate, new ParameterExpression[] { pe }));
    IQueryable<Request> result = _db.Requests.Provider.CreateQuery<Request>(where);
    var list = result.ToList();
