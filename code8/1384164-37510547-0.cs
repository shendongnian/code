    public partial class Object2
    {
        [Key]
        [Column("Property2", Order=2)]
        [ForeignKey("Object1")]
        public short Property2 { get; set; }
        [Key]
        [Column("Property3", Order=1)]
        public short Property3 { get; set; }
        [Key]
        [Column("Property1", Order=0)]
        [ForeignKey("Object1")]
        public int Property1 { get; set; }
    }
