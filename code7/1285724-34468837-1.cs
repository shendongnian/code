	Random rnd = new Random();
	int selectedId =
		db
			.Messages
			.Where(x => x.LastDateUsed < DateTime.Today)
			.Select(x => new { x.Id, x.LastDateUsed })
			.ToArray()
			.SelectMany(x =>
				Enumerable.Repeat(x.Id, DateTime.Today.Subtract(x.LastDateUsed).Days))
			.OrderBy(x => rnd.Next())
			.Concat(new [] { -1 })
			.First();
