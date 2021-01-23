    private static IQueryable<Item> ApplyOptimizedOdataOptions(IQueryable<Item> origQuery,  ODataQueryOptions<Item> options)
    {
    	var defaultOdataQuerySettings = new ODataQuerySettings();
    	if (options.Top != null && options.OrderBy != null)
    	{
    		// We can optimze this query. Apply the OrderBy first, then Top.
    		IQueryable results = options.OrderBy.ApplyTo(origQuery, defaultOdataQuerySettings);
    		results = options.Top.ApplyTo(results, defaultOdataQuerySettings);
    		results = options.ApplyTo(results, defaultOdataQuerySettings, AllowedQueryOptions.Top | AllowedQueryOptions.OrderBy);
    
    		return results as IQueryable<Item>;
    	}
    
    	return options.ApplyTo(origQuery, defaultOdataQuerySettings) as IQueryable<Item>;
    }
