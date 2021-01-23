    try
	{
	    File.Move("oldfilename", "newfilename"); // Try to move
	    Console.WriteLine("Moved"); // Success
	}
	catch (IOException ex)
	{
	    Console.WriteLine(ex); // Write error
	}
