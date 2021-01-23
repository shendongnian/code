    var query = _orderRepoTable.AsQueryable();
    switch (orderState)
    {
      case "OrderStateChanged": query = query.Where(c => c.OrderStateChanged != 0); break;
      ...
    }
    // Now query has the filters you want.
