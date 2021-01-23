    public partial class Category
    {
        public Category()
        {
            this.SubCategory = new HashSet<Category>();
        }
    
        public int Id { get; set; }
        public string Title { get; set; }
        public Nullable<int> ParentId { get; set; }
    
        public virtual ICollection<Category> SubCategory { get; set; }
        public virtual Category ParentCategory { get; set; }
    }
