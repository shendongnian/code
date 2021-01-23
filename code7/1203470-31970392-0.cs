	// It will free resources on its own.
	//
	using (StreamReader reader = new StreamReader("file.txt"))
	{
	    line = reader.ReadLine();
	}
	Console.WriteLine(line);
    }
