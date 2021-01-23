    [RoutePrefix("api/records")]
    public class RecordsController: ApiController
        // GET api/records/products?yearid=10    
        [HttpGet]
        [Route("products")]
        public async Task<Product> GetByYearid(int yearId)
        {
              .....     
        }
    
        // GET api/records/products/15
        [HttpGet]
        [Route("products/{productId:int}")]
        public async Task<IEnumerable<Product>> GetByid(int productId)
        {
            ......
        }
    }
