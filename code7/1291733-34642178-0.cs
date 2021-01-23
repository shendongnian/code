    public class RootObject
    {
        [Key]
        public int RootObjectId { get; set; }
        public int? EvensAObjectId { get; set; }
        public int? OddsBObjectId { get; set; }
        [ForeignKey("EvensAObjectId")]
        public virtual AObject AObject { get; set; }
        [ForeignKey("OddsBObjectId")]
        public virtual BObject BObject { get; set; }
    
        public string Name { get; set; }
    }
