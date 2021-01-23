    public class Shipment
    {
        public int ShipmentId { get; set; }  
       
        //NO FK here
            
        public virtual ShipmentNumber ShipmentNumber { get; set; }
    }
    public class ShipmentNumber
    {
        public int ShipmentId { get; set; } //ShipmentNumber PK is Also Shipment FK
        public virtual Shipment Shipment { get; set; }
    }
