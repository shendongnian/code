    OrderItems = el.Element("OrderItems")
        .Elements("OrderItem")
        .Select(orderItem => new OrderItem()
        {
            ProductName = (string)orderItem.Element("ProductName"),
            Price = (decimal)orderItem.Element("Price"),
            Quantity = (int)orderItem.Element("Quantity"),
        })
        .ToList(),
