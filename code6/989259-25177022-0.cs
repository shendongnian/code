	List<List<string>()> users;
	using (StreamReader reader = new StreamReader("file.txt"))
	{
		string line;
		List<string> currentUser;
		while((line = reader.readLine()) != null)
		{
			if(line == "[user]")
			{
                if(currentUser != null)
                     users.Add(currentUser);
				currentUser = new List<string>{line};
			}
			else
			{
				currentUser.Add(line);
			}
		}
	}
