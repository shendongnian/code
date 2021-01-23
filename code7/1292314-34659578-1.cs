    public class ProductViewModel
    {
       [Display(Name = "Name for Categories")]
       public IEnumerable<Category> Categories { get; set; }
       [Display(Name = "Name for Subcategories ")]
       public IEnumerable<Subcategory> Subcategories { get; set; }
       [Display(Name = "Name for Producty ")]
       public IEnumerable<Product> Product { get; set; }
       [Display(Name = "Name for ProductyDetails ")]
       public IEnumerable<ProductDetails> ProductyDetails { get; set; }
    }
