	for (int i = 0; i < length; i++)
	{
		for (int j = 0; j < length; j++)
		{
			if (i == j) continue;
		
			if (players[i].number == players[j].number)
			{
				Console.WriteLine("Same");
				Console.ReadLine();
			}
			else
			{
				Console.WriteLine("Not");
				Console.ReadLine();
			}
		}
