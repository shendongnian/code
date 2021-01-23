    TransactionOptions transOptions = new TransactionOptions();
    transOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
    
    var orderNumber = 1;
    Order order = null;
    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, transOptions))
    {
        if (db.Orders.Any(o => o.OrderNumber.HasValue))
        {
            // 1. Get the last successful order OrderNumber
            var lastSuccessfulOrder = db.Orders.Where(o => o.OrderNumber.HasValue).OrderByDescending(o => o.OrderNumber).FirstOrDefault();
            if (lastSuccessfulOrder != null)
            {
                orderNumber = lastSuccessfulOrder.OrderNumber.Value + 1;
            }
        }
        // 2. Create the new order with null values except OrderNumber column
        order = new Order();
        order.OrderNumber = orderNumber;
        db.Orders.Add(order);
        System.Threading.Thread.Sleep(2000);
        db.SaveChanges();
        scope.Complete();
    }
