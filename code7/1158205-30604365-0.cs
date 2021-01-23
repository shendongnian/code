    public partial class Object1
    {
        [Key]
        public Guid uid { get; set; }
        public int sequenceNumber { get; set; }
        public bool triggerFlag { get; set; }
        public Guid Object2Id { get; set; }
        public int Object3Id { get; set; }
    }
    public partial class Object2
    {
        [Key]
        public Guid uid { get; set; }
        [Required]
        [StringLength(50)]
        public string model { get; set; }
        [StringLength(3)]
        public string Type { get; set; }
        [StringLength(10)]
        public string alias { get; set; }
    }
    public partial class Object3
    {
        [Key]
        public int uid { get; set; }
        // Other fields...
    }
