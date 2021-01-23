    [Table("OrderTrackingDetails")]
    public class OrderTrackingDetailEntity
    {
        public int          OrderTrackingID         { get; set; }
        [ForeignKey("OrderTrackingID")]
        public OrderTrackingEntity OrderTracking         { get; set; }
    
        // EF Keeps on selecting this field
        [Key, Column(Order = 1)]
        public int          ID                      { get; set; }
    
        public string       LineNumber              { get; set; }
        public decimal?     UnitPrice               { get; set; }
        public int          Quantity                { get; set; }
    }
