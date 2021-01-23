    [RoutePrefix("api/inventoryonhand")]
    public class InventoryOnHandController : ApiController {
        public InventoryOnHandController(){}
    
        //GET api/inventoryonhand
        [HttpGet]
        [Route("")]
        [CacheOutput(ClientTimeSpan = 50, MustRevalidate = true)]
        public IHttpActionResult GetAllInventoryOnHand() {
           // Do stuff
        }
    }
