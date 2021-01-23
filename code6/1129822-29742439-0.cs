    public class BillingAddress
    {
        public string bill_address_id { get; set; }
        public string order_id { get; set; }
    }
    
    public class Lookup
    {
        public string lookup_id { get; set; }
        public string order_id { get; set; }
    }
    
    public class ShippingAddress
    {
        public string ship_address_id { get; set; }
        public string order_id { get; set; }
    }
    
    public class BaseOrder
    {
        public string order_id { get; set; }
        public BillingAddress BillingAddress { get; set; }
        public List<Lookup> Lookup { get; set; }
        public ShippingAddress ShippingAddress { get; set; }
    }
    
    public class BaseOrderShipment
    {
        public string shipment_id { get; set; }
        public string order_id { get; set; }
    }
    
    public class BaseOrderShipmentLineitem
    {
        public string line_item_id { get; set; }
        public string order_id { get; set; }
        public string shipment_id { get; set; }
    }
    
    public class RootObject
    {
        public BaseOrder BaseOrder { get; set; }
        public BaseOrderShipment BaseOrderShipment { get; set; }
        public List<BaseOrderShipmentLineitem> BaseOrderShipmentLineitem { get; set; }
    }
