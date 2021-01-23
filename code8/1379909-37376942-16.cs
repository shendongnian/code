    public class ProductViewModel
    {
        private ProductService _productService = new ProductService();
        public IEnumerable<Product> GetProducts(string name)
        {
           return _productService.GetProducts(name);
        }
    }
