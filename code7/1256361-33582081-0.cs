    public class ProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
    }
    public class ConsumingClass {
    {
        private readonly IProductService _productService = new ProductService(new ProductXmlRepository());
     
        // methods to use the the product service
    }
