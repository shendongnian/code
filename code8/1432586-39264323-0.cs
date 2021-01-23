    var matchingProviders = new List<Provider<TEntity>>();
    Parallel.ForEach(providers,
    	() => new
    	{
    		context = new MyDbContext(),
    		matchingProviders = new List<Provider<TEntity>>()
    	},
    	(provider, state, data) =>
    	{
    		if (data.context.Set<TEntity>().Any(provider.Condition))
    			data.matchingProviders.Add(provider);
    		return data;
    	},
    	data =>
    	{
    		data.context.Dispose();
    		if (data.matchingProviders.Count > 0)
    		{
    			lock (matchingProviders)
    				matchingProviders.AddRange(data.matchingProviders);
    		}
    	}
    );
