    var summary = from order in dbContext.Orders
                  group order by order.CustomerId into g
                  select new { 
                      CustomerName = g.First().CustomerName , 
                      Shoe = g.Count(s => s.OrderType == "Shoe"),
                      Hat = g.Count(s => s.OrderType == "Hat"),
                      Sock = g.Count(s => s.OrderType == "Sock"),
                      TotalOrders = g.Count()
                  };
