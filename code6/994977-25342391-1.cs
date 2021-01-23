    public static class EnumerableEx
    {
    	public static IEnumerable<TReturn> ZipAll<T1, T2, TReturn>(
            this IEnumerable<T1> first, IEnumerable<T2> second,
            Func<T1, T2, TReturn> f,
            T1 seed1, T2 seed2)
        {
    		var iter1 = first.GetEnumerator();
    		var iter2 = second.GetEnumerator();
    		
    		while(iter1.MoveNext())
    		{
    			if(iter2.MoveNext())
    				yield return f(iter1.Current, iter2.Current);
    			else
    				yield return f(iter1.Current, seed2);
    		}
    		
    		while(iter2.MoveNext())
    			yield return f(seed1, iter2.Current);
        }
    
    	public static IEnumerable<TReturn> ZipAll<T1, T2, TReturn>(
            this IEnumerable<T1> first,
            IEnumerable<T2> second,
            Func<T1, T2, TReturn> f)
    	{
            return first.ZipAll(second, f, default(T1), default(T2));
    	}
    }
