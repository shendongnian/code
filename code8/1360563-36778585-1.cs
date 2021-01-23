	try
	{
		try { throw new Exception(); }
		finally { Console.WriteLine("finally"); }
		Console.WriteLine("Where am I?");
	}
	catch { Console.WriteLine("catched"); }
