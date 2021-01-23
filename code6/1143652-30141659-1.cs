    var baseQuery = from o in _db.Orders
                    join l in _db.OrderLines.Where(x => x.ParaBirimi == model.ParaBirimi) on o.orderId equals l.OrderId
                    where o.OrderDate.Value.Year == year1
                    select new { Order = o, OrderLine = l };
    if (something)
    {
         baseQuery = baseQuery.Where(x => x.Order.Foo == "Bar");
    }
    var myQuery = (from o in baseQuery
                   group o by new { o.Order.OrderDate.Value.Month }
                       into g
                       select
                           new
                           {
                               Month = g.Key.Month,
                               Total = g.Sum(t => t.OrderLine.OrderTotal)
                           });
