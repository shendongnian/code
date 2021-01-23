	public string IsAuthenticUser(string userId, string password)
	{
		string userPass = string.Format("{0}:{1}", userId, password);
		string[] tokens = System.Configuration.ConfigurationManager.AppSettings["authenticUsers"]
                                .Split(new string[] {",", "=>"}, StringSplitOptions.RemoveEmptyEntries);
		for (int i = 0; i < tokens.Length; i += 2)
		{
			if (tokens[i] == userPass)
			{
				return tokens[i + 1];
			}
		}
		return null; // no match.
	}
