	string Studentnames[] = new string[]
	{
		"George",
		"Goblin",
		"Peter",
		"TJ"
	}
	
	while (retry != "No")
	{
		if (Studentnames.Contains(Studentname)
		{
			Console.WriteLine("Yes in the list");
			Console.ReadLine();
		}
		else
		{
			Console.WriteLine("Not in the list");
			Console.WriteLine("Would you like to retry?");
			retry = Console.ReadLine();
		}
	}
