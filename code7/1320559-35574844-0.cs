    [RoutePrefix("api/{companyName}")]
    public class CustomerController : ApiController {
        // GET api/MyCompany/products
        [Route("products")]
        public IEnumerable<Product> GetCustomerProducts(int companyName) { ... }
        // GET api/MyCompany/orders
        [Route("orders")]
        public IEnumerable<Order> GetCustomerOrders(int companyName) { ... }
        ....
    }
