    public class ProductDetailsViewModel
    {
        public virtual Product Product { get; set; }
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
    }
