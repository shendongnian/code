    public class ProductPageViewModel
    {
       public ProductViewModel Product { get; set; }
       public Guid SelectedBrand { get; set; }
       public IEnumerable<ProductBrandViewModel> ProductBrands { get; set; }
    }
