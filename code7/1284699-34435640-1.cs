    public class Order
    {
        public string OrderId { get; set; }
        public int ShippingAddressId {get; set;}
        public virtual Address ShippingAddress { get; set; }
        public int BillingAddressId {get; set;}
        public virtual Address BillingAddress { get; set; }
    }
