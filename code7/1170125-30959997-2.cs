    public static class QueryableExtensions
    {
    	public static IOrderedQueryable<TSource> OrderByWithDirection<TSource,TKey>
    		(this IQueryable<TSource> source,
    		Expression<Func<TSource, TKey>> keySelector,
    		string orderDir)
    	{
    		return orderDir == "Desc" 
    						? source.OrderByDescending(keySelector)
    						: source.OrderBy(keySelector);
    	}
    }
