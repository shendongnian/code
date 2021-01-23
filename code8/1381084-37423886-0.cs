    var q5 = from p in db.Products
                     from od in db.Order_Details
                     .Where (od => od.ProductID == p.ProductID)
                     .Where (od=> od.Quantity > 50).DefaultIfEmpty()
                     select (od.OrderID !=null ? "-" : p.ProductName)
                     ;
            foreach (var p in q5)
            {
                if(p != "-")
                {
                     Console.WriteLine(p);
                }   
            }
