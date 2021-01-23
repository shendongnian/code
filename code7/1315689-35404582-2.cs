    public class User : IDbSet, IParent
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public int? parentId { get; set; } 
        public virtual User Parent { get; set; }
        public virtual ICollection<User> Children { get;set; }
    }
