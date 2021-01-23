		var times = 100000;
		string s = "abc";
		Stopwatch sw = new Stopwatch();
		sw.Start();
		for (var i = 0; i < times; i++)
		{
			bool notEmpty1 = s.Length != 0;
		}
		var diff = sw.Elapsed;
		sw.Restart();
		for (var i = 0; i < times; i++)
		{
			bool notEmpty2 = s.Length > 0;
		}
		var gt = sw.Elapsed;
		sw.Restart();
		for (var i = 0; i < times; i++)
		{
			bool notEmpty3 = !string.IsNullOrEmpty(s);
		}
		var noe = sw.Elapsed;
		sw.Restart();
		for (var i = 0; i < times; i++)
		{
			bool notEmpty4 = s.Any();
		}
		var any = sw.Elapsed;
		sw.Restart();
		for (var i = 0; i < times; i++)
		{
			bool notEmpty4 = s != string.Empty;
		}
		var dif2 = sw.Elapsed;
		Console.WriteLine(string.Format("!= {0}\n> {1}\nIsNullOrEmpty {2}\nAny {3}\n!= empty {4}", diff.TotalMilliseconds, gt.TotalMilliseconds, noe.TotalMilliseconds, any.TotalMilliseconds, dif2.TotalMilliseconds));
