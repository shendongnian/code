    db.Configuration.LazyLoadingEnabled = false;
    var intermed = (from c in db.Customers                 
                    where customerId = 5
                    select new
                    {
                        Customer = c,
                        ...
                        Orders = c.Orders
                    }).ToListAsync();
    var dtos = intermed.Select(x => new myDTO
                                    {
                                        Customer = x.Customer,
                                        ...
                                    }).ToList();
