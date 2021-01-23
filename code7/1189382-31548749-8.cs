    public class Registration
    {
        public string id { get; set; }
        public string displayName { get; set; }
    }
    public class Order
    {
        public Registration registration { get; set; }
        public object quantity { get; set; }
        public string itemStatusDescription { get; set; }
    }
    public class OrderDate
    {
        public long date { get; set; }
        public string locale { get; set; }
        public string timeInUserTimeZone { get; set; }
        public object timeInCustomTimeZone { get; set; }
        public object dateInCustomTimeZone { get; set; }
        public int customTimeZoneDate { get; set; }
        public string timeInLocale { get; set; }
        public string dateInUserTimeZone { get; set; }
    }
    public class OrderDetail
    {
        public string orderStatus { get; set; }
        public List<Order> orderItems { get; set; }
        public string orderContact { get; set; }
        public string orderNumber { get; set; }
        public OrderDate orderDate { get; set; }
    }
    public class RootObject
    {
        public string orderId { get; set; }
        public OrderDetail orderDetail { get; set; }
    }
