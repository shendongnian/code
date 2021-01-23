    Console.WriteLine("Time elapsed: {0} start", stopwatch.Elapsed);
    var productInfo =
    	from product in products
    	join line in totalOrderLines on product equals line.Sku into orderLines
    	select new { Product = product, OrderLines = orderLines };
    var orderIds = new HashSet<string>(); // for cumulative count
    foreach (var item in productInfo)
    {
    	foreach (var line in item.OrderLines)
    		orderIds.Add(line.OrderId);
    	cumulativeStoreTable.Rows.Add(item.Product, orderIds.Count);
    	// Remove the next if it was just to support your processing
    	productStore.Add(item.Product);
    }
    Console.WriteLine("Time elapsed: {0} end", stopwatch.Elapsed);
