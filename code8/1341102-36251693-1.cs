    [RoutePrefix("product")]
    public class ProductController : ApiController {
        // ... other code removed for brevity
    
        // Insert 
        // eg: POST /product/insert
        [HttpPost]
        [Route("insert")] 
        public string Insert([FromBody] Product newProd) {...}
    }
