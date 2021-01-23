    public class ProductsController
    {
        private IStoreRepository StoreRepository {get; set;}
    
        //When the controller is created, we'll initialize our data access layer
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
