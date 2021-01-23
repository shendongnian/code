    var list = Enumerable.Range(1, 1000000).ToList();
	
	for(var i = 0; i < 100; i++)
	{
		var warmupA = list.WhereEx(a => a > 500000).ToList();
		var warmupB = list.Where(a => a > 500000).ToList();;
		var warmupC = list.WhereExCompile(a => a > 500000).ToList();;
	}
	
	var sw = new Stopwatch();
	sw.Start();
	
	for(var i = 0; i < 100; i++)
	{
		var wherexresult =  list.WhereEx(a => a > 500000).ToList();
	}
	
	sw.Stop();
	var wherextime = sw.ElapsedMilliseconds;
	
	sw = new Stopwatch();
	sw.Start();
	
	for(var i = 0; i < 100; i++)
	{
		var whereresult =  list.Where(a => a > 500000).ToList();
	}
	
	sw.Stop();
	var whertime = sw.ElapsedMilliseconds;
	
	sw = new Stopwatch();
	sw.Start();
	
	for(var i = 0; i < 100; i++)
	{
		var whereexcompileresult =  list.WhereExCompile(a => a < 500000).ToList();
	}
	
	sw.Stop();
	var whereexcompiletime = sw.ElapsedMilliseconds;
	
	wherextime.Dump();
	whertime.Dump();
	whereexcompiletime.Dump();
    public static class a  {
    	public static IEnumerable<T> WhereExCompile<T>(this IEnumerable<T> query, Expression<Func<T, bool>> exp)
    	{
    		return query.AsQueryable().Where(exp);
    	}
    	public static IEnumerable<T> WhereEx<T>(this IEnumerable<T> query, Expression<Func<T, bool>> exp)
    	{
    		return query.Where(exp.Compile());
    	}
    }
