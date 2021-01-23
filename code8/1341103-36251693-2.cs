    [RoutePrefix("supplier")]
    public class SupplierController : ApiController {
        // ... other code removed for brevity
    
        // Insert 
        // eg: POST /supplier/insert
        [HttpPost]
        [Route("insert")] 
        public string Insert([FromBody] Product newProd) {...}
    }
