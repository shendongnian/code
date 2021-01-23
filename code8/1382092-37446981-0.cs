    private static IEnumerable<UserRole> FindAllChildren(List<UserRole> allRoles, UserRole role)
    {
    	var childrenByParentId = allRoles.ToLookup(r => r.ParentId);
    	var stack = new Stack<IEnumerator<UserRole>>();
    	var e = childrenByParentId[role != null ? role.Id : (int?)null].GetEnumerator();
    	try
    	{
    		while (true)
    		{
    			while (e.MoveNext())
    			{
    				yield return e.Current;
    				stack.Push(e);
    				e = childrenByParentId[e.Current.Id].GetEnumerator();
    			}
    			if (stack.Count == 0) break;
    			e.Dispose();
    			e = stack.Pop();
    		}
    	}
    	finally
    	{
    		e.Dispose();
    		while (stack.Count > 0) stack.Pop().Dispose();
    	}
    }
