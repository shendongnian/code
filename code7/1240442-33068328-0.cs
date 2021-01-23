    public static class Extensions
    {
    	public static IEnumerable<T> ThenByHierarchy<T, TKey>(this IOrderedEnumerable<T> source, Func<T, TKey> keySelector, Func<T, TKey> parentKeySelector)
    	{
    		var itemByKey = source.ToDictionary(keySelector);
    		var processSet = new HashSet<T>();
    		var stack = new Stack<T>();
    		foreach (var item in source)
    		{
    			for (var next = item; processSet.Add(next); )
    			{
    				stack.Push(next);
    				if (!itemByKey.TryGetValue(parentKeySelector(next), out next)) break;
    			}
    			while (stack.Count != 0)
    				yield return stack.Pop();
    		}
    	}
    }
