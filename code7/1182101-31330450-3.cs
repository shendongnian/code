	var pageSize = 4;
	Func<Record, Result> process = r =>
	{
		Thread.Sleep(100); // Only here to demonstrate parallelism
		return new Result(r.ID);
	};
	var query =
		Observable
			.Using(
				() => new DataProcessor(),
				dc =>
					Observable
						.Range(0, int.MaxValue)
						.Select(n => dc.GetRecords(n, pageSize))
						.TakeWhile(rs => rs.Any())
						.SelectMany(rs => rs)
						.Select(r => Observable.Start(() => process(r)))
						.Merge(maxConcurrent: 4));
	var subscription =
		query
			.Subscribe(
				r => Console.WriteLine(r.ID),
				() => Console.WriteLine("Done."));
