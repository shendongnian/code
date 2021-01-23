	var sw = new System.Diagnostics.Stopwatch();
	int numItems = 50000000;
	var stack = new Stack<int>();
	sw.Restart();
	for (int i = 0; i < numItems; ++i)
		stack.Push(i);
	sw.Stop();
	var totalTime = sw.Elapsed.TotalSeconds;
	Console.WriteLine("Push time: {0:#,#0.00}ms", 1000 * totalTime);
	Console.WriteLine("Time per item: {0:#,#0.00}ns", (1000000000.0 * totalTime) / numItems);
