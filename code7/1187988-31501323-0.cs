    //setup basic query
    var query = from r in document.Descendants("Orders")
    			select new
    			{
    				OrderID = r.Element("OrderID").Value,
    				CustomerID = r.Element("CustomerID").Value,
    				EmployeeID = r.Element("EmployeeID").Value,
    			};
    			
    //setup query result ordering,
    //assume we have variable to determine ordering mode : bool isDesc = true/false
    if (isDesc) query = query.OrderByDescending(o => o.OrderID);
    else query = query.OrderBy(o => o.OrderID);
    
    //setup pagination, 
    //f.e displaying result for page 2 where each page displays 100 data
    var page = 2;
    var pageSize = 100;
    query = query.Skip(page - 1*pageSize).Take(pageSize);
    //execute the query to get the actual result
    var items = query.ToList();
