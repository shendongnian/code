    while (true) // Loop indefinitely
    	{
    	    Console.WriteLine("Username: "); // Prompt
    	    string line = Console.ReadLine(); // Get string from user
            if (hashSet.Contains(line)) {
                 Console.WriteLine("Username Already in Use");
                 continue;
            }
    	    if (line == "exit") // have a way to exit, you can do whatever you want
    	    {
    		break;
    	    }
    	    // Here add to both file and your HashSet...
    	}
