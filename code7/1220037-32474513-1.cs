	var random = new Random();
	var _sensor = Observable.Generate(
		0,
		x => true,
		x => x,
		x => random.NextDouble() * 16.0,
		x => TimeSpan.FromSeconds(random.NextDouble()));
	var published_sensor = _sensor.Publish();
	var notification = published_sensor.Publish(ps => ps
		.Select(x => x >= 15.0)
		.DistinctUntilChanged()
		.Select(p => p
			? Observable.Empty<double>()
			: Observable
				.Timer(TimeSpan.FromSeconds(5.0))
				.Select(x => -1.0)
				.IgnoreElements()
				.Concat(ps))
		.Switch());
	published_sensor.Merge(notification).Timestamp().Dump();
	published_sensor.Connect();
