	try
	{
		try { throw new Exception(); }
		finally { Console.WriteLine("finally"); }
	}
	catch { Console.WriteLine("catched"); }
