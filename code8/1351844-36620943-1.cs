    public IProductsManagerProvider : IProductsManager
    {
        
    }
    public class ProductsManagerProvider : IProductsManagerProvider
    {
        private readonly IUnitOfWork _uow;
        private readonly IProductsDataService _dataService;
    
        public ProductsManagerProvider (IUnitOfWork uow, IProductsDataService dataService)
        {
            _dataService = dataService;
            _uow = uow;
        }
    
        public bool AddProduct(ProductEntity product)
        {
            var addedProduct = _dataService.AddProduct(product);
            if (addedProduct != null)
                _uow.Commit();
        }
    }
