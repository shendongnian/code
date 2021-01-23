	var pingTasks = ipaddress.Select(ip =>
	{
		using (var ping = new Ping())
		{
			return ping.SendPingAsync(ip);
		}
	}).ToList();
	
