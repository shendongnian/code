     var groupedOrders = orders.GroupBy(i => i.CustomerId)
                               .Select(i => new { CUSTOMER = i.Key, 
                                                  ORDERS = i.Select(j => j.ProductId)
                                                            .OrderBy(j => j)
                                                            .ToArray() })
                               .ToList();
    
     var result = groupedOrders.GroupBy(i => i.ORDERS, new IntArrayComparer()).ToList();
