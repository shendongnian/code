    try {
        ...
    }
	catch (ArgumentOutOfRangeException e)
	{
		Console.WriteLine("Arguments Out of Range: {0}", e.Message);
	}
	catch (ArgumentException e)
	{
		Console.WriteLine("Invalid Arguments: {0}", e.Message);
	}
