	var l = loadips();
	var t = func();
	var faileds = new ConcurrentQueue<YourClass>();
	Parallel.ForEach(l.ToArray(), (ip_item) =>
	{
		try
		{
		    ...
		}
		catch
		{
			Console.WriteLine(ip_item.IP + " - BAD!");
			faileds.Enqueue(ip_item);
		}
	});
	foreach (var item in l.Except(faileds))
	{
		if (item.AcceptsConnection == true)
		{
			Console.WriteLine(ip + " Working proxy.");
		}
	}
