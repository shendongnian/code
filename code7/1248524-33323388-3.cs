    var results = (
	    from o in Orders
		group o by o.CustomerId into og // create a grouping of orders by customerID
		orderby og.Count() descending // sort by number of orders in each grouping
		join c in Customers on og.Key equals c.Id // og.Key is the grouping Key (CustomerId)
        select new MostActive
        {
            FirstName = c.FirstName,
            LastName = c.LastName,
            Id = c.Id,
            Count = og.Count()
        }).Take(10);
