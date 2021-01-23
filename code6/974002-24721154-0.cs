	var query =
		list
			.Scan(new
			{
				Price = 0,
				IsFirst = true,
				First = 0,
				Second = 0,
				Final = 0
			}, (a, x) => new
			{
				Price = x.Price,
				IsFirst = x.IsFirst,
				First = x.IsFirst ? x.Price : 0,
				Second = !x.IsFirst ? x.Price : 0,
				Final = a.Final + (x.IsFirst ? x.Price : - x.Price)
			});
