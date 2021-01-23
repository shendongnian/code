    [RoutePrefix("stuff")]
    public class MyController : ApiController
    {
        [Route("myAction/{id}")] //route to this is via /stuff/myAction/{id}
        [HttpGet]
        public HttpResponseMessage MyMethod(string id)  
        { ... }
    }
