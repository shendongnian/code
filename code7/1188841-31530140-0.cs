	var query =
		from order in GetOrderStream("FNZCTEST")
		from price in GetPriceStream(order.Exchange, order.Security)
			.DefaultIfEmpty(new PriceDto())
		select new
		{
			Order = order,
			Price = price,
		};
	IDisposable disposable =
		query.Subscribe(x => Console.WriteLine("{0} : {1}", x.Order, x.Price));
