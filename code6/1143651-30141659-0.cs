    var baseQuery = from o in _db.Orders    
                    join l in _db.OrderLines.Where(x => x.ParaBirimi == model.ParaBirimi) on o.orderId equals l.OrderId
                    where o.OrderDate.Value.Year == year1 
                    select new { Orders = o, OrderLines = l };
    if (something)
    {
         baseQuery = baseQuery.Where(x => x.Orders.Foo == "Bar");
    }
    var myQuery = (from o in baseQuery
                   group o by new {o.Orders.OrderDate.Value.Month}
                   into g
                   select
                       new
                       {
                           Month = g.Key.Month,
                           Total = g.Select(t => t.OrderLines.Sum(s => s.OrderTotal)).FirstOrDefault()
                       });
