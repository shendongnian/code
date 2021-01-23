	var query =
		from Products in db.Products
		join ProductProperties in db.ProductProperties on Products.ProductId equals ProductProperties.ProductId
		join Properties in db.Properties on ProductProperties.PropertyId equals Properties.PropertyId
		group new
		{
			ProductProperties.PropertyValue,
			Properties.PropertyName,
			ProductProperties.PropertyId
		} by Products;
	
	List<MyProduct> lii =
		query
			.ToArray()
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
