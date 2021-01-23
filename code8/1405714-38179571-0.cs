	public static class Extensions
	{
		public static IOrderedQueryable<TSource> Order<TSource, TKey>(
			this IQueryable<TSource> source, 
			Expression<Func<TSource, TKey>> keySelector, 
			bool descending = false)
		{
			return descending 
                ? source.OrderByDescending(keySelector)
                : source.OrderBy(keySelector);
		}	
	}
