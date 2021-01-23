	Random rn = new Random();
	List<int> l = new List<int>();
	System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
	for (int j = 1; j <= 20; ++j)
	{
		l.Clear();
		sw.Start();
		if (j % 2 == 0)
		{
			Console.Write("A: ");
			for (int i = 0; i < 100000000; ++i)
			{
				int var_a = rn.Next(1, 10000) * (rn.NextDouble() <= 0.5 ? -1 : 1);
				if (var_a != null)
					if (var_a > 0) var_a *= -1;
				l.Add(var_a);
			}
		}
		else
		{
			Console.Write("B: ");
			for (int i = 0; i < 100000000; ++i)
			{
				int var_a = rn.Next(1, 10000) * (rn.NextDouble() <= 0.5 ? -1 : 1);
				if (var_a != null && var_a > 0) var_a *= -1;
				l.Add(var_a);
			}
		}
		sw.Stop();
		Console.WriteLine(sw.Elapsed.TotalMilliseconds);
		sw.Reset();
	}
