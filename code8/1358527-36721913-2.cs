     public class Product
        {
            [Display(Name="Choose product:")]
            public int Product { get; set; }
            [Display(Name="Stock:")]
            public string Stock { get; set; }
            public List<Products> Products { get; set; }
        }
    
