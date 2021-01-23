	var sw = Stopwatch.StartNew();
	Enumerable
		.Range(0, files)
		.GroupBy(x => 10 * x / files)
		.AsParallel()
		.ForAll(ns =>
			ns
				.ToList()
				.ForEach(n =>
					System.IO.File.Move(
						System.IO.Path.Combine(path, n.ToString(format) + ".txt"),
						System.IO.Path.Combine(path, n.ToString(format) + n.ToString(format) + ".txt"))));
	sw.Stop();
