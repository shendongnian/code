    public class Resource
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ResourceId { get; set; }
        public virtual Profile Profile { get; set; }
    }
