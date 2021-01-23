    public class Item
    {
        [Key]
        public Guid ItemId { get; set; }
        // dynamic properties for the open type
        public IDictionary<string, object> DynamicProperties { get; set; }}
        
        ... 
    }
