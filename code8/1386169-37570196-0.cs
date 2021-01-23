    [RoutePrefix("products")]
    public class ProductsController : ApiController {
    
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllProduct()
        {
            //...
        }
    
        [HttpGet]
        [Route("{productId}")]
        public IHttpActionResult GetProductById(int id)
        {
            //...
        }
    
        [HttpPost]
        [Route("")]
        public IHttpActionResult SaveProduct(Product product)
        {
            //...
        }
    
        [HttpGet]
        [Route("{productId}/getcolor")]
        public IHttpActionResult GetProductColorById(int id)
        {
            //...
        }
    
        [HttpGet]
        [Route("{productId}/getcost")]
        public IHttpActionResult GetProductCostById(int id)
        {
            //...
        }
    }
