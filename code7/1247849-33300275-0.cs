    public class OrdersService
    {
        public void RemoveOrderLine(OrderLine orderLine)
        {
            // get db context (or some repository)
            var context = GetDbContext();
            // attach or load entities, etc.
    
            context.OrderLines.Remove(orderLine);
            if (!order.OrderLines.Any())
            {
                context.Orders.Remove(order);
            }        
        }
    }
