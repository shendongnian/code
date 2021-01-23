            var xEle = new XElement("Orders",
                          from order in orders
                          select new XElement("Order",
                                       new XAttribute("OrderNumber", order.OrderNumber),
                                         new XElement("CustomerId", order.CustomerID)
                                     , from line in order.OrderLines 
                                           select new XElement("Line",   new XAttribute("ProductCode", line.ProductCode),
                                         new XElement("OrderQty", line.OrderQty))));
            xEle.Save("orders.xml");
            Console.WriteLine("Converted to XML");
