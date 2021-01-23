	string filename = @"PingLog.csv";
	{
		using (var writer = new StreamWriter(filename, true))
		{
			Console.SetOut(writer);
			var ping = new WebSitePing();
			ping.Ping();
		}
	}
