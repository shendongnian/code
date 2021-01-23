    public bool AddPath(Dictionary<int, HashSet<int>> paths, int x, int y)
    {
    	if (!paths.ContainsKey(x))
    	{
    		paths[x] = new HashSet<int>() { };
    	}
    
    	if (!paths[x].Contains(y))
    	{
    		paths[x].Add(y);
    		if (!paths.ContainsKey(y))
    		{
    			paths[y] = new HashSet<int>() { };
    		}
    		return true;
    	}
    	return false;
    }
