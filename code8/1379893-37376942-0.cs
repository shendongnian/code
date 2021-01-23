    public class ProductViewModel
    {
        private ProductService _productService = new ProductService();
        public IEnumerable<Product> GetProductByName(string name)
        {
           _productService.GetProducts();
        }
    }
