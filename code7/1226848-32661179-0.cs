        Console.Write("What do you want to do?: ");
        string line = Console.ReadLine();
        if (line.StartsWith("exit"))
        {
            Environment.Exit(0); 
        }
        // Notice the space after the create word
        if (line.StartsWith("create ")) 
        {
            Create(line.Substring(6)); 
        }
        else
            Console.WriteLine("command does not exist\n");
