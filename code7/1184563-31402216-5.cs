    public static class IEnumerableExtension
    {
    	public static IEnumerable<IEnumerable<T>> GroupAdjacentBy<T>(
    		this IEnumerable<T> source, Func<T, T, bool> predicate)
    	{
    		using (var e = source.GetEnumerator())
    		{
    			if (e.MoveNext())
    			{
    				var list = new List<T> { e.Current };
    				var pred = e.Current;
    				while (e.MoveNext())
    				{
    					if (predicate(pred, e.Current))
    					{
    						list.Add(e.Current);
    					}
    					else
    					{
    						yield return list;
    						list = new List<T> { e.Current };
    					}
    					pred = e.Current;
    				}
    				yield return list;
    			}
    		}
    	}
    }
