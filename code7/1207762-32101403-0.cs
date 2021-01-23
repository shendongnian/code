    [Table("CustomDataMulti")]
    public partial class CustomDataMulti : BaseEntity
    {
        [Key]
        public int CustomDataMultiId { get; set; }
    
        public int CustomDataId { get; set; }
    
        [Required]
        [StringLength(150)]
        public string CustomValue { get; set; }
    
        [Required]
        public virtual CustomData CustomData { get; set; }
    }
