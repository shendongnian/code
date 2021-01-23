	var measurements =
		methods
			.Select((m, i) => i)
			.ToDictionary(i => i, i => new List<double>());
	for (var run = 0; run < 1000; run++)
	{
		for (var i = 0; i < methods.Length; i++)
		{
			var sw = Stopwatch.StartNew();
			var gccc0 = GC.CollectionCount(0);
			var r = methods[i]();
			var gccc1 = GC.CollectionCount(0);
			sw.Stop();
			if (gccc1 == gccc0)
			{
				measurements[i].Add(sw.Elapsed.TotalMilliseconds);
			}
		}
	}
	var results =
		measurements
			.Select(x => new
			{
				index = x.Key,
				count = x.Value.Count(),
				average = x.Value.Average().ToString("0.000")
			});
