	var r = new Random();
	var a = Enumerable.Range(0, 1000);
	var i = Observable.Interval(TimeSpan.FromSeconds(2.0));
	var sw = Stopwatch.StartNew();
	var query =
		i.Zip(a, (ii, aa) => aa)
			.SelectMany(aa => Observable.Start(() =>
			{
				var x = sw.Elapsed.TotalMilliseconds;
				Thread.Sleep(r.Next(0, 5000));
				return x;
			}))
			.Select(x => new
			{
				started = x,
				ended = sw.Elapsed.TotalMilliseconds
			});
