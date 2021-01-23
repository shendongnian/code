	try
	{
		try
		{
			throw new ArgumentException() { Source = "One" };
			throw new ArgumentException() { Source = "Two" };
			throw new ArgumentException() { Source = "Three" };
		}
		catch (ArgumentException ex) when (ex.Source.StartsWith("One")) // local
		{
			Console.WriteLine("This error is handled locally");
		}
		catch (ArgumentException ex) when (ex.Source.StartsWith("Two")) // separate
		{
			Console.WriteLine("This error is handled locally");
		}
	}
	catch (ArgumentException ex) // global all-catcher
	{
		Console.WriteLine("This error is handled globally");
	}
