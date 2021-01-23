	 var activeFilters = filters
		.Select(s => s.Split(' '))
		.Select(s => Tuple.Create(s[0][0], TimeSpan.FromMilliseconds(int.Parse(s[1]))))
		.Select(t => Observable.Timer(t.Item2, scheduler).Select(_ => t.Item1).StartWith(t.Item1))
		.MergeCombineLatest(true)
		.StartWith(new List<char>());
	var output = activeFilters.Publish(_activeFilters => 
			input.Join(_activeFilters,
				_ => Observable.Return(1),
				t => _activeFilters,
				(c, filterList) => Tuple.Create(c, filterList)
			)
		)
		.Where(t => !t.Item2.Contains(t.Item1))
		.Select(t => t.Item1);
	var observer = scheduler.CreateObserver<char>();
	output.Subscribe(observer);
	scheduler.Start();
	ReactiveAssert.AreElementsEqual(
		expected.Messages,
		observer.Messages);
