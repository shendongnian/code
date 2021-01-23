    public class ParentEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } 
        public virtual ChildEntity Child { get; set; }
    }
    
    public class ChildEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public ParentEntity Parent { get; set; }
    }
