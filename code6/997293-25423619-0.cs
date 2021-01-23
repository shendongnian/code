    public class Equipment
    {
        [Key]
        public int EquipmentId { get; set; }
        public virtual List<EquipmentRelation> Parents { get; set; }
        public virtual List<EquipmentRelation> Children { get; set; }
    }
    public class EquipmentRelation
    {
        [Key]
        [Column("ChildId", Order=1)]
        public int ChildId { get; set; }
        [Key]
        [Column("ParentId", Order=2)]
        public int ParentId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public Equipment Parent { get; set; }
        [Required]
        public Equipment Child { get; set; }
    }
