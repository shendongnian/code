	public static IEnumerable<string> GetColumns()
	{
		int depth = 1;
		while (true)
		{
			foreach (var column in GetColumns(depth))
				yield return column;
			depth++;
		}
	}
	
	private static IEnumerable<string> GetColumns(int depth)
	{
		string letters = "abcdefghijklmnopqrstuvwxyz";
		foreach (var c in letters)
			if (depth == 1)			
				yield return c.ToString();
			else
			{
				foreach (var sub in GetColumns(depth - 1))
					yield return c + sub;
			}
	}
