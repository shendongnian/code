    [RoutePrefix("api/{companyName}")]
    public class CustomerController : ApiController {
        // GET api/MyCompany/products
        [Route("products")]
        public IEnumerable<Product> GetProducts(string companyName) { ... }
        // GET api/MyCompany/orders
        [Route("orders")]
        public IEnumerable<Order> GetOrders(string companyName) { ... }
        ....
    }
