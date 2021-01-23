     var groupedCustomers = 
             orders.GroupBy(i => i.CustomerId)
                   .Select(i => new { CUSTOMER = i.Key, 
                                      ORDERS = i.Select(j => j.ProductId)
                                                .OrderBy(j => j)
                                              //.Distinct() to ignore duplicate orders
                                                .ToArray() })
                   .ToList();
    
     var result = groupedCustomers.GroupBy(i => i.ORDERS, new IntArrayComparer()).ToList();
