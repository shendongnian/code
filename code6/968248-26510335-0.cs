    public abstract class TrackedEntity
    {
        [Column(TypeName = "varchar")]
        [MaxLength(48)]
        [Required]
        public string ModifiedBy { get; set; }
    
        [Required]
        public DateTime Modified { get; set; }
    
        public int Version { get; set; }
    }
