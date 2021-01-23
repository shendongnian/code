	List<OrderBundle> dividedOrderBundels = new List<OrderBundle>();
	foreach (OrderBundle orderBundle in orderBundels)
	{
		int bundelCount = (int)Math.Ceiling(orderBundle.OrderIds.Count() / 6.0);
		for (int i = 0; i < bundelCount; i++)
		{
			OrderBundle divided = new OrderBundle
			{
				RepId = orderBundle.RepId,
				OrderIds = orderBundle.OrderIds.Skip(i * 6).Take(6).ToList()
			};
			dividedOrderBundels.Add(divided);
		}
	}      
