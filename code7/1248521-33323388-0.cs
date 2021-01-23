    var results = orders
        .GroupBy(o => o.CustomerId)
        .OrderByDescending(og => og.Count())
        .Take(10)
        .Select(og => new {
            Customer = customers.Single(c => c.Id.Equals(og.Key)),
            Orders = og
        })
        .Select(c => new MostActive {
            Id = c.Customer.Id,
            FirstName = c.Customer.FirstName,
            LastName = c.Customer.LastName,
            Count = c.Orders.Count()
        });
