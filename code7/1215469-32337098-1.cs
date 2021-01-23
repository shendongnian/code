	public static string ReplaceTopLevelCommas(string query)
	{
		var newQuery = new StringBuilder();
		var level = 0;
		
		foreach (var c in query)
		{
			if (c == ',')
			{
				if (level == 0)
				{
					newQuery.Append("+\"|\"+");
				}
				else
				{
					newQuery.Append(c);
				}
			}
			else
			{
				if (c == '(')
				{
					level++;
				}
				else if (c == ')')
				{
					level--;
				}
				
				newQuery.Append(c);
			}
		}
		
		return newQuery.ToString();
	}
