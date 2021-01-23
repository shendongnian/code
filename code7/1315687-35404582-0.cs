    public class User : IDbSet, IParent
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        // notice that parent's id should be 
        // optional [at some point your parent will have to be null], 
        // thus we make the foreign key nullable
        public int? parentId { get; set; } 
        [ForeignKey("parentId")]
        public virtual User Parent { get; set; }
    }
