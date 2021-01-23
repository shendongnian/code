    group new { o, l } by new {  o.OrderID,o.Nature,od.TotalPrice,o.Date,os.OrderStatus,
                                 l.FirstName, l.EmailAddress,l.PhoneNumber } into g
                          select new orderDetailModel
                          {
                              OrderID = g.Key.OrderID,
                              OrderStatus = g.Key.OrderStatus,
                              Date = g.Key.Date,
                              ..and so on
                          };
