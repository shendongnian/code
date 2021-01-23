    var res = from c in customers
              join o in orders on c.Id equals o.CustomerId
              where o.Id == (orders.where(x=>x.CustomerId == o.CustomerId).OrderByDescending(x=>x.Id)).First().Id
              && DateTime.Compare(o.Date, DateTime.Now.AddDays(-1)) > 0
              select new CustomerOrders {
    	          CustomerId = c.Id, FirstName = c.FirstName, LastName = c.LastName,
    	          OrderId = o.Id, Date = o.Date, Product = o.Product 
              };
