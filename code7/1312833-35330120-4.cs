    public async Task<List<Entity_Basic>> DynamicWhereAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
    	// Register async extension method from entity framework (this should be done in the global.asax or STAThread method
    	// Only Enumerable && Queryable extension methods exists by default
    	EvalManager.DefaultContext.RegisterExtensionMethod(typeof(QueryableExtensions));
    
    	// GET your criteria
    	var tuples = new List<Tuple<string, object>>();
    	tuples.Add(new Tuple<string, object>("Specialty", "Basket Weaving"));
    	tuples.Add(new Tuple<string, object>("Rank", "12"));
    
    	// BUILD your where clause
    	var where = string.Join(" && ", tuples.Select(tuple => string.Concat("x.", tuple.Item1, " > p", tuple.Item1)));
    
    	// BUILD your parameters
    	var parameters = new Dictionary<string, object>();
    	tuples.ForEach(x => parameters.Add("p" + x.Item1, x.Item2));
    
    	using (var ctx = new TestContext())
    	{
    		var query = ctx.Entity_Basics;
    
    		// ADD the current query && cancellationToken as parameter
    		parameters.Add("q", query);
    		parameters.Add("token", cancellationToken);
    
    		// GET the task
    		var task = (Task<List<Entity_Basic>>)Eval.Execute("q.Where(x => " + where + ").ToListAsync(token)", parameters);
    
    		// AWAIT the task
    		var result = await task.ConfigureAwait(false);
    		return result;
    	}
    }
