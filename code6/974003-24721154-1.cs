	var query =
		list
			.Aggregate(new []
			{
				new
					{
						Price = 0,
						IsFirst = true,
						First = 0,
						Second = 0,
						Final = 0
					}
			}.ToList(), (a, x) =>
			{
				a.Add(new
				{
					Price = x.Price,
					IsFirst = x.IsFirst,
					First = x.IsFirst ? x.Price : 0,
					Second = !x.IsFirst ? x.Price : 0,
					Final = a.Last().Final + (x.IsFirst ? x.Price : - x.Price)
				});
				return a;
			})
			.Skip(1);
