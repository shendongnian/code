    try
	{
		String filePath = @"C:\TEMP\test.txt";
		using (var fs = new StreamWriter(filePath))
		{
			fs.Write("data");
		}
		
		Console.WriteLine("File written");
		
        // Fails
		System.IO.File.Copy(filePath, filePath, true);
		
		Console.WriteLine("File overwritten by itself");
		
	}
	catch (Exception exc)
	{
		Console.WriteLine(exc.Message);
	}
