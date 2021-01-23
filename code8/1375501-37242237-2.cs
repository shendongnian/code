    public class Product
    {
        public int ProductId { get; set; } 
        public int? SubcategoryId { get; set; }
        public virtual Subcategory Subcategory { get; set; }
        public string Name { get; set; }
        public string Presentation { get; set; }
        public string Image { get; set; }
        public string Alt { get; set; } 
        public bool IsDeleted { get; set; }
    }
    using System.ComponentModel.DataAnnotations;
    public class ProductViewModel
    {
        public int? SubcategoryId { get; set; }
        public string Name { get; set; }
        public string Presentation { get; set; }
        public string Image { get; set; }
        public string Alt { get; set; }
        [Required]
        public int? SelectedSubcategory { get; set; }
        public IEnumerable  Subcategory { get; set; }
    }
