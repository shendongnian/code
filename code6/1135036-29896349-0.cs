	public DataTable Select(string query, params string[] parameters)
	{
		return Select(query, (IEnumerable<string>)parameters);
	}
	public DataTable Select(string query, IEnumerable<string> parameters)
	{
		return null;
	}
