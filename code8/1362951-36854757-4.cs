	var query =
		from Products in db.Products
		join ProductProperties in db.ProductProperties on Products.ProductId equals ProductProperties.ProductId
		join Properties in db.Properties on ProductProperties.PropertyId equals Properties.PropertyId
		select new
		{
			ProductProperties.PropertyValue,
			Properties.PropertyName,
			ProductProperties.PropertyId,
			Products.ProductName,
			Products.ProductPrice
		};
	List<MyProduct> lii =
		query
			.ToArray()
			.GroupBy(x => new
			{
				x.ProductName,
				x.ProductPrice
			}, x => new
			{
				x.PropertyValue,
				x.PropertyName,
				x.PropertyId
			})
			.Select(x => new MyProduct()
			{
				Name = x.Key.ProductName,
				pros = x
					.Select(y => new MyProperty()
					{
						PropertyName = y.PropertyName,
						PropertyValue = y.PropertyValue,
					})
					.ToList()
			})
			.ToList();
