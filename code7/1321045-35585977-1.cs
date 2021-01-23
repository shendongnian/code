    Console.WriteLine("Time elapsed: {0} start", stopwatch.Elapsed);
    var productInfo =
    (
    	from product in productsToSearch
    	join line in totalOrderLines on product equals line.Sku into orderLines
    	select new { Product = product, OrderLines = orderLines }
    ).ToList();
    var lastIndexByOrderId = new Dictionary<string, int>();
    for (int i = 0; i < productInfo.Count; i++)
    {
    	foreach (var line in productInfo[i].OrderLines)
    		lastIndexByOrderId[line.OrderId] = i; // Last wins
    }
    int cumulativeCount = 0;
    for (int i = 0; i < productInfo.Count; i++)
    {
    	var product = productInfo[i].Product;
    	foreach (var line in productInfo[i].OrderLines)
    	{
    		int lastIndex;
    		if (lastIndexByOrderId.TryGetValue(line.OrderId, out lastIndex) && lastIndex == i)
    		{
    			cumulativeCount++;
    			lastIndexByOrderId.Remove(line.OrderId);
    		}
    	}
    	cumulativeStoreTable.Rows.Add(item.Product, cumulativeCount);
    	// Remove the next if it was just to support your processing
    	productStore.Add(item.Product);
    }
    Console.WriteLine("Time elapsed: {0} end", stopwatch.Elapsed);
