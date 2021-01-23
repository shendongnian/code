    var result = (from a in ctx.Orders
                             join b in ctx.OrderDetails on a.OrderId Equals b.OrderId
                             where a.Field1.Equals(id) && b.Field1.Contains("TEST")
                             select new 
                             {
                                 OrderId = a.OrderId,
                                 Field1 = a.Field1,
                                 Field2=a.Field2, 
                                 OrderDate = a.OrderDate.Month + "/" + a.OrderDate.Day + "/" + a.OrderDate.Year
                             }).AsEnumerable().Select(x => new myClass.CDOrder
                             {
                                 OrderId = x.OrderId,
                                 Field1 = x.Field1,
                                 Field2=x.Field2, 
                                 OrderDate = x.OrderDate             
                             });
