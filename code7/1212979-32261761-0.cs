    [Table("items")]
    public class items
    {
        public int id { get; set; }
        public string text { get; set; }
        public string value { get; set; }
        
        [NotMapped]
        public int test { get; set; }
    }
