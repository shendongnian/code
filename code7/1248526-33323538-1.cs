        Customers.Select(c => new MostActive {
                  FirstName = c.FirstName,
                  LastName = c.LastName,
                  Id = c.Id,
                  Count = c.Orders.Count()
                  })
            .OrderByDescending(o => o.Count)
            .Take(10);
