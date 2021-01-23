	foreach (var customer in
		collListItem.Select(
			item =>
			new Customer {
					ResourceName = item["Resource_x0020_Name"].ToString(),
					Quantity = (item["Quantity_x0020_Ordered"] ?? 0),
					CustomerName = item["Title"].ToString()
			}
		)
		.Where(r => r.CustomerName == "test"))
	{
		resources.Add(customer);
	}
