    bool exists = false;
    while(!exists)
    {
        Console.WriteLine("Username: ");
        string uCreation = Console.ReadLine();
    
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
        }
    }
