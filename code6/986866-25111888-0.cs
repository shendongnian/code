      public class ProductsController:ApiController
        {
    
    
    
            [HttpGet]
            [Route("api/Restaurant/{restaurantName}")]
            public IHttpActionResult Get(string restaurantName)
            {
                //do stuff
                return Ok("api/Restaurant/{restuarantName}");
            }
    
            [HttpGet]
            [Route("api/restuarant/{restaurantName}/terminals")]
            public IHttpActionResult GetDevices(string restaurantName)
            {
                //do stuff
                return Ok("api/restuarant/{restaurantName}/terminals");
            }
    
            [HttpGet]
            [Route("api/restaurant/{restaurantName}/terminals/{terminalName}")]
            public IHttpActionResult GetDeviceByName(string restaurantName, string terminalName)
            {
                //do stuff
                return Ok("api/restaurant/{restaurantName}/terminals/{terminalName}");
            }
        }
