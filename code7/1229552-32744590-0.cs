    var orders = context.Orders;
    
    if (territory != null)
    {
        orders = orders.Where(x.Territory != null && x.Territory.Id == territory.Id)
    }
