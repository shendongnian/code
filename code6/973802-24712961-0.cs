    customerService.Include(c => c.Orders)
    .Select(x => new CustomerVM
                   {
                     Name = x.Name,
                     Orders = x.Orders.Select(order => new OrderVM { ItemName = order.ItemName }).ToList() 
                   }
    
