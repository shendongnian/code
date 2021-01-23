	int index = 0;
	var result2 = data
		.OrderBy(item => item.Product_ID)
		.ThenBy(item => item.Date)
		.Lag(1, (current, previous) => new { Index = (current.Price == previous?.Price ? index : ++index), Item = current })
		.GroupBy(item => new { item.Index, item.Item.Product_ID, item.Item.Price })
		.Select(group => new Record { Product_ID = group.Key.Product_ID, Price = group.Key.Price, Date = group.Min(item => item.Item.Date) })
		.ToList();
