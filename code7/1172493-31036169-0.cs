    public class OrderController : ApiController
    {
        public Order PostOrder([FromBody] OrderItem[] orderitems)
        {
            if (orderitems != null)
            {
                Order order = new Order();
                order.OrderItems = orderitems.ToList<OrderItem>();
    
                return order;
            }
            return null;
        }
    }
