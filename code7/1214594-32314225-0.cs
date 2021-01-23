    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string TagName { get; set; }
        public string TagColor { get; set; }
        public string ImageUrl { get; set; }
        [ForeignKey("CategoryId")]
        public virtual ICollection<Category> SubCategories { get; set; }
    }
