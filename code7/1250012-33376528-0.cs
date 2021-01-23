    [RoutePrefix("bindingTest")]
    public class BindingTestController : ApiController
    {
        [Route("")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Product data)
        {
            return Request.CreateResponse();
        }
    }
