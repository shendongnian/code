	var xs = new [] { 1, 2, 3, 0, 4, 0, 5 }.ToObservable();
	
	xs
		.Select(x =>
		{
			if (x == 0)
				throw new NotSupportedException();
			else
				return x;
		})
		.Subscribe(
			x => Console.WriteLine(x),
			ex => Console.WriteLine(ex.ToString()));
