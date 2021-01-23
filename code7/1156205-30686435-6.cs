    [RoutePrefix("api/endpoint1")]
    public class DefaultController : ApiController
    {
        [Route("{value:int}")]
        public string Get(int value)
        {
            return "TestController.Get: value=" + value;
        }
    }
    
    [RoutePrefix("api/endpoint2")]
    public class Endpoint2Controller : ApiController
    {
        [Route("segment/segment")]
        public string Post()
        {
            return "Endpoint2:Post";
        }
    }
