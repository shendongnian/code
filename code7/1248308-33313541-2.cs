    var results = customers
        .Select(c =>
            orders
                .Where(o => o.CustomerId == c.Id)
                .Where(o => o.Date.Date == DateTime.Now.AddDays(-1).Date)
                .OrderByDescending(o => o.Date)
                .DefaultIfEmpty()
                .Select(o => new CustomerOrders()
                {
                    Product = o == null ? default(string) : o.Product,
                    Date = o == null ? default(DateTime) : o.Date,
                    CustomerId = c.Id,
                    LastName = c.LastName,
                    FirstName = c.FirstName,
                    OrderId = o == null ? default(Guid) : o.Id
                })
                .First())
        .ToList();
