	public static string ReplaceTopLevelCommas(string query)
	{
		var newQuery = new StringBuilder();
		
		foreach (var c in query)
		{
			if (c == ',')
			{
				newQuery.Append("+\"|\"+");
			}
			else
			{
				newQuery.Append(c);
			}
		}
		
		return newQuery.ToString();
	}
