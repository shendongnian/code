    public class ProductController: ApiController{
    
        private IProductCommandService commandService;
        private IProductQueryService queryService;
        private IIdGenerationService idGenerator;
    
        [HttpPost]
        public ActionResult Create(Product product){
            var newProductId = idGenerator.NewId();
            product.Id = newProductId;
            commandService.AddProduct(product);
 
            return this.Url.Link("Default", new { Controller = "Product", Action = "GetProduct", id = newProductId });
        }
    
        [HttpGet]
        public ActionResult GetProduct(Guid id){
            return queryService.GetProduct(id);
        }
    }
