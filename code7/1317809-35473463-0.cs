    [RoutePrefix("notproducts")]
    public class ProductsController : ApiController
    {
        [Route("")]
        public IEnumerable<Product> Get() { ... }
    }
