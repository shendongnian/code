    var results = Orders
        .GroupBy(o => o.CustomerId)
        .OrderByDescending(og => og.Count())
        .Take(10)
        .Select(og => new {
            Customer = Customers.Single(c => c.Id.Equals(og.Key)),
            Orders = og
        })
        .Select(c => new MostActive {
            Id = c.Customer.Id,
            FirstName = c.Customer.FirstName,
            LastName = c.Customer.LastName,
            Count = c.Orders.Count()
        });
