	int groupingIndex = 0;
	int previousPrice = 0;
	var response = data
		.OrderBy(item => item.Product_ID)
		.ThenBy(item => item.Date)
		.Select(item =>
		{
			if (item.Price != previousPrice)
			{
				previousPrice = item.Price;
				groupingIndex++;
			}
			return new { Index = groupingIndex, Item = item };
		})
		.GroupBy(item => new { item.Index, item.Item.Product_ID, item.Item.Price } )
		.Select(group => new Record 
        { 
            Product_ID = group.Key.Product_ID, 
            Price = group.Key.Price, 
            Date = group.Min(item => item.Item.Date) 
        }).ToList();
