    public class ParentEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } 
        public virtual ICollection<ChildEntity> Children { get; set; }
    }
    
    public class ChildEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [ForeignKey("Parent")]
        public Guid ParentId { get; set; }
        public ParentEntity Parent { get; set; }
    }
