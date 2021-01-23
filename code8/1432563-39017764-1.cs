    var parameter = Expression.Parameter(typeof(TEntity), "e");
    var indexQuery = providers
    	.Select((provider, index) => queryable
    		.Where(provider.Condition)
    		.Take(1)
    		.Select(Expression.Lambda<Func<TEntity, int>>(Expression.Constant(index), parameter)))
    	.Aggregate(Queryable.Concat);
    
    var indexes = indexQuery.ToList();
    var matchingProviders = indexes.Select(index => providers[index]);
