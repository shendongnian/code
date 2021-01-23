    public class ProductManager : IProductManager
    {
        private readonly IProductService _productService;
        public ProductManager([WithKey("CachedProductService")]IProductService productService)
        {
            _productService = productService;
        }
    }
