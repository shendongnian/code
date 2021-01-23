    List<SalesOrder> salesOrders = new List<SalesOrder>()
    {
        new SalesOrder()
        {
            OrderDate = DateTime.Now,
            OrderDetails = new List<SalesOrderDetail>()
            {
                new SalesOrderDetail() { ItemId = 1 },
                new SalesOrderDetail() { ItemId = 2 },
                new SalesOrderDetail() { ItemId = 3 }
            }
        },
        new SalesOrder()
        {
            OrderDate = DateTime.Now,
            OrderDetails = new List<SalesOrderDetail>()
            {
                new SalesOrderDetail() { ItemId = 1 },
                new SalesOrderDetail() { ItemId = 2 }
            }
        }
    };
    
    _context.SalesOrders.AddRange(salesOrders);
    _context.SaveChanges();
