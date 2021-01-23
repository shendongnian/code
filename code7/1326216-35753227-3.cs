    [RoutePrefix("api/test")]
    public class TestController : ApiController
    {
        [Route("{id}")]
        public string Get(int id)
        {
            return "value";
        };
            
    }
