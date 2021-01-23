    public partial class JDEController : ApiController
    {
    
    	[Route("orders")]
        public IEnumerable<Order> Get(int customerId) { ... }
    }
