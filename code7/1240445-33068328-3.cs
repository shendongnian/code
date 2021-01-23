    public static class Extensions
    {
    	public static IEnumerable<T> HierarchicalOrder<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector, Func<T, TKey> parentKeySelector, Func<IEnumerable<T>, IOrderedEnumerable<T>> order)
    	{
    		// Collect parent/child relation info
    		var itemById = source.ToDictionary(keySelector);
    		var childListById = new Dictionary<TKey, List<T>>();
    		var rootList = new List<T>();
    		foreach (var item in itemById.Values)
    		{
    			var parentKey = parentKeySelector(item);
    			List<T> childList;
    			if (parentKey == null || !itemById.ContainsKey(parentKey))
    				childList = rootList;
    			else if (!childListById.TryGetValue(parentKey, out childList))
    				childListById.Add(parentKey, childList = new List<T>());
    			childList.Add(item);
    		}
    		// Traverse the tree using in-order DFT and applying the sort on each sublist
    		return order(rootList).Expand(item =>
    		{
    			List<T> childList;
    			return childListById.TryGetValue(keySelector(item), out childList) ? order(childList) : null;
    		});
    	}
    	public static IEnumerable<T> Expand<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> elementSelector)
    	{
    		var stack = new Stack<IEnumerator<T>>();
    		var e = source.GetEnumerator();
    		try
    		{
    			while (true)
    			{
    				while (e.MoveNext())
    				{
    					var item = e.Current;
    					yield return item;
    					var elements = elementSelector(item);
    					if (elements == null) continue;
    					stack.Push(e);
    					e = elements.GetEnumerator();
    				}
    				if (stack.Count == 0) break;
    				e.Dispose();
    				e = stack.Pop();
    			}
    		}
    		finally
    		{
    			e.Dispose();
    			while (stack.Count != 0) stack.Pop().Dispose();
    		}
    	}
    }
