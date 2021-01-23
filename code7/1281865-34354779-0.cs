    Stopwatch sw = new Stopwatch();
	List<Action> actions = new List<Action>();
    actions.Add(() => { Thread.Sleep(1000); Console.WriteLine($"1 - {sw.ElapsedMilliseconds}"); });
    actions.Add(() => { Thread.Sleep(10000); Console.WriteLine($"2 - {sw.ElapsedMilliseconds}"); });
    actions.Add(() => { Thread.Sleep(3000); Console.WriteLine($"3 - {sw.ElapsedMilliseconds}"); });
    actions.Add(() => { Thread.Sleep(3000); Console.WriteLine($"4 - {sw.ElapsedMilliseconds}"); });
    sw.Start();
	Parallel.ForEach(actions, new ParallelOptions
	{
		MaxDegreeOfParallelism = 2
	}, action => action());
