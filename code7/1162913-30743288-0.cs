        var orderList = _context.Set<FixedOrder>()
            .Include(fo => fo.Client)
           .ForCurrentDay(date)
           .Where(fo => !fo.Client.IsInactive)
           .ConsideringOrderSubstitution(orderSubstitutes.Select(os => os.FixedOrderId).ToList())
           .Join(clientSet
               , o => o.ClientId
               , c => c.Id
               , (o, c) =>
                   new 
                   {
                       OrderId = orderSubstitutes.Where(os => os.FixedOrderId == o.Id).Select(os => os.OrderId).FirstOrDefault() ?? 0,
                       Client = c,
                       HasFixedOrders = true,
                       FixedOrderId   = o.Id,
                       HasSpecialProducts = false
                   }
           ).ToList()
           .Select(t=>new OrderDTO {
                       OrderId = t.OrderId,
                       ClientId = t.Client.Id,
                       ClientName = t.Client.Name,
                       HasFixedOrders = t.HasFixedOrders,
                       FixedOrderId   = t.FixedOrderId,
                       ShippingHour = GetShippingHour(t.Client,date),
                       HasSpecialProducts = t.HasSpecialProducts
           }).ToList();
