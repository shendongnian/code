    public class HomeController : Controller 
    {
        private readonly IProductService _productService;
    
        public HomeController(IProductService service)
        {
            this._productService = service;
        }
    
     public ActionResult index() {
    
            //this is OK
            var products = this._productService.FindAll();
    
            //this is also OK
            var product = this._productService.Find(Guid.Parse("some_guid"));
    
            this._productService.CreateProduct(
                id = Guid.newGuid(),
                name = "Vader Shirt",
                price = 99.5
            );
    
            return this.View();
        }
    }
