	Enumerable
		.Range(1, 10)
		.AsParallel()
		.ForAll(async i =>
		{
			var index = i % 2;
			Console.WriteLine($"Trying Index {index}");
			_results.TryAdd(index,
				new AsyncLazy<LongRunningResult>(
					() => ComputeLongRunningResult(index),
					LazyThreadSafetyMode.ExecutionAndPublication));
			AsyncLazy<LongRunningResult> ayncLazy;
			if (_results.TryGetValue(index, out ayncLazy))
			{
				await ayncLazy;
			}
		});
