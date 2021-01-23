    [MyRoutePrefix]
    public class OrdersController : ApiController
    {
        [HttpGet]
        [Route("customers/{id:int}/orders")]
        public IHttpActionResult GetCustomerOrders(int id) {...}
    }
    public class MyRoutePrefixAttribute : RoutePrefixAttribute
    {
        public MyRoutePrefixAttribute() 
        {
            Prefix = "the route prefix";
        }
    }
