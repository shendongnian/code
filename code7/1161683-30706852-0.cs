	IObservable<DateTimeOffset> daily =
		Observable
			.Create<long>(o =>
			{
				var startTime = DateTimeOffset.Now.Date.Add(new TimeSpan(15, 30, 0));
				if (startTime < DateTimeOffset.Now)
				{
					startTime = startTime.AddDays(1.0);
				}
				return Observable.Timer(startTime, TimeSpan.FromDays(1.0)).Subscribe(o);
			})
			.Select(n => DateTimeOffset.Now);
