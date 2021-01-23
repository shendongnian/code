    public static class TreeHelper
    {
    	public static IEnumerable<T> PreOrderTraversal<T>(T node, Func<T, IEnumerable<T>> childrenSelector)
    	{
    		var stack = new Stack<IEnumerator<T>>();
    		var e = Enumerable.Repeat(node, 1).GetEnumerator();
    		try
    		{
    			while (true)
    			{
    				while (e.MoveNext())
    				{
    					var item = e.Current;
    					yield return item;
    					var children = childrenSelector(item);
    					if (children == null) continue;
    					stack.Push(e);
    					e = children.GetEnumerator();
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
