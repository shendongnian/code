    public static IList<Order> GetOrdersAndItems()
    {
		List<Order> orders;
		using (var context = new ShopDC())
		{
			context.Database.Log = Console.WriteLine;
			Console.WriteLine("Orders: " + context.Orders.Count());
			orders = context.Orders
				.Where(o => o.OrderID > 0)
				// Tells EF to eager load all the items
				.Include(o => o.Items)
				.ToList();
		}
		return orders;
	}
