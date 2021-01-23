	var groupedResults = Results
		.GroupBy(r => new { r.TrdID, r.Date, r.Price })
		.Where(g => g.Count() == 2)
		.Select(g => new Result
		{
			TrdID = g.Key.TrdID,
			Date = g.Key.Date,
			Price = g.Key.Price,
			Seller = g.FirstOrDefault(x => x.Seller != null).Seller,
			Buyer = g.FirstOrDefault(x => x.Buyer != null).Buyer
		});
