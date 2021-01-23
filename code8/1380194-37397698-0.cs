    var orders = context.Orders
        .GroupBy(i => i.Clients.ClientName)
        .Select(i => i.OrderByDescending(it => it.OrderDate).FirstOrDefault())
        .Select(o => new OrderDto
                     {
                         o.OrderNumber,
                         o. ... // More Order properties
                         Client = o.Clients.Name
                     });
