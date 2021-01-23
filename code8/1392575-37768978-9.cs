	private static string GetLineA()
	{
		string s = Console.ReadLine();
		if (s == null)
		{
			return GetLineA();
		}
		return s;
	}
	
