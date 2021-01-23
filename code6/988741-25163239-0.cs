    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Service
    {
        ...
        public virtual Category Category { get; set; }
        public virtual Category Subcategory { get; set; }
    }
    // Do the same when adding category/subcategory fields to `Business`
