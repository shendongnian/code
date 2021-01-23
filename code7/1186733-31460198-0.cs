    public class Order
    {
        public string OrderID { get; set; }
        public DeliveryAddress DeliveryAddress { get; set; }
        
        [XmlElement("OrderItem")]
        public List<OrderItem> OrderLine { get; set; }
    }
