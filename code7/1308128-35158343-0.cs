    public static class LinqEx
    {
    	public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> src, 
                                                         Func<T, TKey> keySelector)
    	{
    		return src.GroupBy(keySelector).Select(g=>g.First());
    	}
    }
