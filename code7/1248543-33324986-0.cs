	var obs = Observable.Create<int>(innersub =>
	{
		var count = 0;
		return Observable.Interval(TimeSpan.FromSeconds(2))
			.Subscribe(x => innersub.OnNext(count++));
	});
	obs.Subscribe(x => Console.WriteLine(x));
