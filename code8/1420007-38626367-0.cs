    public List<OrderViewModel> GetCustOrders()
    {
        var query = orders
            .GroupBy(c => c.CustomerName)
            .Select(o => new OrderViewModel{
                CustomerName = o.Key,
                Shoe = o.Where(c => c.OrderType == "Shoe").Count(c => c.CustomerId),
                Hat = o.Where(c => c.OrderType == "Hat").Count(c => c.CustomerId),
                Sock = o.Where(c => c.OrderType == "Sock").Count(c => c.CustomerId),
                Total = o.Count(c => c.CustomerId)
            });
    
        return query;
    }
  
