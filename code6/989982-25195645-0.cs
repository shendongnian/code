	var timespans = new List<TimeSpan>();
	while (true)
	{
		var count = GC.CollectionCount(0);
		var sw = Stopwatch.StartNew();
		/* run test here */
		sw.Stop();
		if (count == GC.CollectionCount(0))
		{
			timespans.Add(sw.Elapsed);
		}
		if (timespans.Count == 100)
		{
			break;
		}
	}
