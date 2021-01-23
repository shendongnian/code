    IQueryable<Order> items = var items = Db.Orders;
    
    if(siteid != null)
    {
        items = items.Where(item => item.SiteId == siteid);
    }
    if (CycleID != null)
    {
        items = items.Where(item => item.OrderOrderLifeCycles.First().OrderLifeCycleId == CycleID);
    }
    // etc.
