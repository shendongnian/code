    var group = Expression.Parameter(typeof(IGrouping<int, TEntity>), "g");
    
    var anyMethod = typeof(Enumerable)
        .GetMethods()
        .First(m => m.Name == "Any" && m.GetParameters()
        .Count() == 2)
        .MakeGenericMethod(typeof(TEntity));
    
    var concatArgs = Providers.Select(provider => 
        Expression.Call(anyMethod, group, 
        Expression.Lambda(provider.Condition.Body, provider.Condition.Parameters)));
    
    var convertExpression = concatArgs.Select(concat =>
        Expression.Condition(concat, Expression.Constant("1"), Expression.Constant("0")));
    
    var concatCall = Expression.Call(
        typeof(string).GetMethod("Concat", new[] { typeof(string[]) }),
        Expression.NewArrayInit(typeof(string), convertExpression));
    
    var selector = Expression.Lambda<Func<IGrouping<int, TEntity>, string>>(concatCall, group);
    
    var matchInfo = queryable
        .GroupBy(e => 1)
        .Select(selector)
        .First();
    
    var MatchingProviders = matchInfo.Zip(Providers,
        (match, provider) => match == '1' ? provider : null)
        .Where(provider => provider != null)
        .ToList();
