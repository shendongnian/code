    // Missing quotes, should probably be a full file path
	string filename = @"C:\temp\PingLog.csv";
	
	// You had an extra opening brace here
	
	// Open a file for writing using the filename, and a flag that means whether to append
	using (var writer = new StreamWriter(filename, false))
	{
	    // Write a CSV header
		writer.WriteLine("Status, Time, Address");
		try
		{
			Ping myPing = new Ping();
			PingReply reply = myPing.Send("www.yahoo.com", 1000);
			if (reply != null)
			{
                // Use the overload of WriteLine that accepts string format and arguments
				writer.WriteLine("{0}, {1}, {2}", reply.Status, reply.RoundtripTime, reply.Address);
			}
		}
		catch
		{                   
			// You had a syntax error here
			Console.WriteLine("ERROR: You have some TIMEOUT issue");
		}
	}
