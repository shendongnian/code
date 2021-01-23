    public class OrdersService
    {
        public void RemoveOrderLine(OrderLine orderLine)
        {
            // get db context (or some repository)
            var context = GetDbContext();
            // attach or load entities, etc.
    
            // this is _business logic_;
            // it is not natural for relational database;
            // it is not related to db context or repositiory
            context.OrderLines.Remove(orderLine);
            if (!order.OrderLines.Any())
            {
                context.Orders.Remove(order);
            }        
        }
    }
