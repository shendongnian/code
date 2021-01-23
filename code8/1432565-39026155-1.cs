    var group = Expression.Parameter(typeof(IGrouping<int, TEntity>), "g");
    
    var concatArgs = providers.Select(provider => Expression.Call(
    		typeof(Enumerable), "Max", new[] { typeof(TEntity), typeof(string) },
    		group, Expression.Lambda(
    			Expression.Condition(
    				provider.Condition.Body, Expression.Constant("1"), Expression.Constant("0")),
    			provider.Condition.Parameters)));
    
    var concatCall = Expression.Call(
    	typeof(string).GetMethod("Concat", new[] { typeof(string[]) }),
    	Expression.NewArrayInit(typeof(string), concatArgs));
    
    var selector = Expression.Lambda<Func<IGrouping<int, TEntity>, string>>(concatCall, group);
    
    var matchInfo = queryable
    	.GroupBy(e => 1)
    	.Select(selector)
    	.FirstOrDefault() ?? "";
    
    var matchingProviders = matchInfo.Zip(providers,
    	(match, provider) => match == '1' ? provider : null)
    	.Where(provider => provider != null)
    	.ToList();
