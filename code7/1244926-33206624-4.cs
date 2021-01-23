	// when enumerated this will result in one SQL statement
	var groupingSource = 
	(
		from key in
		(
			from gc in dc.Customers
			group 1 by new { gc.SalesPerson, gc.LastName } into grp
			orderby grp.Key.SalesPerson, grp.Key.LastName
			select grp.Key
		).Take(10)
		join c in dc.Customers on key equals new { c.SalesPerson, c.LastName }
		select c
	);
	// get the records and re-group them
	var groupedCust = 
		from c in groupingSource.AsEnumerable()
		group c by new { c.SalesPerson, c.LastName } into grp
		orderby grp.Key.SalesPerson, grp.Key.LastName
		select grp;
