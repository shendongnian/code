    public class Category 
    {
        public Guid ID {get; set;}
        public Guid? ParentId {get; set;}
        public Category Parent {get; set;}
        public ICollection<Categories> Children {get; set;}
    }
