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
                         });`
