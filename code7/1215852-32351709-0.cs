    public partial class Stock 
    {
        [Column("StockId")]
        [JsonProperty(PropertyName = "stockid")]
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
    
        [JsonProperty(PropertyName = "devicecode")]
        public DeviceTypes Device { get; set; }
        [ForeignKey("Device")]
        public int DeviceTypesId {get; set;} // new field, holds existing devicetypes id
    }
