	List<Order> orders = new List<Order>()
	{
		new Order { OrderNo = "Prefix1/OrderNo1",CustomerID = 1},
		new Order { OrderNo = "Prefix2/OrderNo2",CustomerID = 7},
		new Order { OrderNo = "Prefix2/OrderNo3",CustomerID = 8},
		new Order { OrderNo = "Prefix1/OrderNo4",CustomerID = 12},
	};
	List<string> AlreadyProcessed = new List<string>()
	{
		"OrderNo2",
		"OrderNo4"
	};
	var ToBeProcessed = orders.Where(o => !AlreadyProcessed.Any(ap => o.OrderNo.Contains(ap)))
							  .Select(o => o.OrderNo);
