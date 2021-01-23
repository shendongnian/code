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
            var result=false;
            var addedProduct = _dataService.AddProduct(product);
            if (addedProduct != null)
                result=_uow.Commit()>0;
            return result;
        }
    }
