	bool restrictInput = true;
	while (restrictInput)
	{
		string key = Console.ReadKey(true).Key.ToString();
		if (key.ToUpper() == "F10")
		{
			Console.WriteLine("Hello!");
			restrictInput = false;
		}
	}
