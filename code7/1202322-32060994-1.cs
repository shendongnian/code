	public static void Run()
	{
		IList<Order> disconnectedOrders = GetOrdersAndItems();
		foreach (var order in disconnectedOrders)
		{
			Console.WriteLine(order.Name);
			foreach (var item in order.Items)
			{
				Console.WriteLine("--" + item.Name);
			}
		}
	}
