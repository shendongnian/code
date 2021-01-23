    public class Category
    {
        public Category()
        {
            CategoryTexts = new List<CategoryText>();
        }
    
        public int Id { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<CategoryText> CategoryTexts { get; set; }
    }
