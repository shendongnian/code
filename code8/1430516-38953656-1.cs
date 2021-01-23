    public class Entry
    {
        [Key]
        [Column(Order = 0)]
        public string Currency { get; set; }
        [Key]
        [Column(Order = 1)]
        public string ExternalId { get; set; }
    }
