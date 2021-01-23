	public static string GetProperty(string friendlyname, string property)
	{
		var user = GetUser(friendlyname);
		try
		{
			return user.Properties[property].Value.ToString();
		}
		catch (NullReferenceException ex)
		{
			throw "No property found";
		}
	}
