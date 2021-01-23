    public class ProductController: Controller{
    
        private IProductCommandService commandService;
        private IProductQueryService queryService;
        private IIdGenerationService idGenerator;
    
        [HttpPost]
        public ActionResult Create(Product product){
            var newProductId = idGenerator.NewId();
            product.Id = newProductId;
            commandService.AddProduct(product);
            //TODO: add url parameter or TempData key to show "product created" message if needed    
            return RedirectToAction("GetProduct", new {id = newProductId});
        }
    
        [HttpGet]
        public ActionResult GetProduct(Guid id){
            return queryService.GetProduct(id);
        }
    }
