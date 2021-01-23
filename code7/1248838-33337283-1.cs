	var data = 
		FILTERED
			.Cast<string>()
			.Select((x, n) => new { x, n })
			.GroupBy(xn => xn.n / 4, xn => xn.x)
			.Select(xs => new
			{
				ID = int.Parse(xs.ElementAt(0)),
				Lession = xs.ElementAt(1),
				Time = int.Parse(xs.ElementAt(2)),
				Score = int.Parse(xs.ElementAt(3)),
			});
