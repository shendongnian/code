    foreach (var customer in
        collListItem.Select(
            item =>
            new
                {
                    ResourceName = item["Resource_x0020_Name"].ToString(),
                    Quantity = (item["Quantity_x0020_Ordered"] ?? 0).ToString(),
                    CustomerName = item["Title"].ToString()
                })
            .Where(r => r.CustomerName == "test")
            .Select(r => new Customer { ResourceName = r.ResourceName, Quantity = int.Parse(r.Quantity) }))
    {
        resources.Add(customer);
    }
