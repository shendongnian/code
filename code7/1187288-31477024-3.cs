    public class ProductsController
    {
        private IStoreRepository StoreRepository {get; set;}
    
        public ProductsController()
        {
            StoreRepository = new MsSqlStoreRepository(Config.ConnectionString); //normally you'd use Dependency Injection instead of constructor
        }
    
        public ActionResult List()
        {
            var products = StoreRepository.GetAllProducts();
            return View(products);
        }
    }
