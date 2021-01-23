    var results = customers
        .Select(c =>
            orders
                .Where(o => o.CustomerId == c.Id)
                .Where(o => o.Date.Date == DateTime.Now.AddDays(-1).Date)
                .OrderByDescending(o => o.Date)
                .Select(o => new CustomerOrders()
                {
                    Product = o.Product,
                    Date = o.Date,
                    CustomerId = c.Id,
                    LastName = c.LastName,
                    FirstName = c.FirstName,
                    OrderId = o.Id
                })
                .First())
        .ToList();
