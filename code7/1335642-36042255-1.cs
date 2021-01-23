    while(true)
    {
        Console.WriteLine("Username: ");
        string uCreation = Console.ReadLine();
		bool exists = false;
        foreach (string lines in File.ReadAllLines("Usernames.txt"))
        {
            if (lines == uCreation)
            {
                Console.WriteLine("Username already exists!");
				exists = true;
				break;
            }
        }
		
		if (!exists)
		{
			File.AppendAllText(@"Usernames.txt", uCreation + Environment.NewLine);
			break;
		}
    }
