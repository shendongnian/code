    public class Shipment
    {
        public int ShipmentId { get; set; }
            
        public virtual ICollection<ShipmentNumber> ShipmentNumbers { get; set; }
    }
    public class ShipmentNumber
    {
        public int ShipmentNumberId { get; set; }
        
        public int ShipmentId { get; set; }
        public virtual Shipment Shipment { get; set; }
    }
