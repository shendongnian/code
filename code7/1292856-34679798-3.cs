	public bool AddPath(Dictionary<int, HashSet<int>> paths, int @from, int @to)
	{
		if (!paths.ContainsKey(@from))
		{
			paths[@from] = new HashSet<int>() { @to, };
			return true;
		}
		else
		{
			if (!paths[@from].Contains(@to))
			{
				paths[@from].Add(@to);
				return true;
			}
			else
			{
				return false;
			}
		}
	}
