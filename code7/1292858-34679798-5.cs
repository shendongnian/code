	public bool AddPath(Dictionary<int, HashSet<int>> paths, int x, int y)
	{
		var wasToAdded = false;
		if (!paths.ContainsKey(x))
		{
			paths[x] = new HashSet<int>() { y, };
			wasToAdded = true;
		}
		else
		{
			if (!paths[x].Contains(y))
			{
				paths[x].Add(y);
				wasToAdded = true;
			}
			else
			{
				wasToAdded = false;
			}
		}
		if (wasToAdded)
		{
			paths[y] = new HashSet<int>() { };
		}
		return wasToAdded;
	}
