	private static string GetLineB()
	{
		string s = Console.ReadLine();
		if (s == null)
		{
			s = GetLineB();
		}
		return s;
	}
	
