    public class Order
    {
        public Order(int orderId, string status)
        {
            OrderId = orderId;
            Status = status;
        }
    
        public int OrderId { get; set; }
        public string Status { get; set; }
    }
