	var TimeList = new [] { "00:00:40", "00:01:00", "00:02:10" };
	
	var TotalTime =
		TimeList
			.Select(itm => TimeSpan.Parse(itm))
			.Aggregate((ts0, ts1) => ts1.Add(ts0));
			
	Console.WriteLine("Total Time: {0}", TotalTime);
