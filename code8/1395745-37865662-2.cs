    [RoutePrefix("api/values")]
    public class ValuesController : ApiController {
        //GET api/values/100/some-string-here
        [HttpGet]
        [Route("{p1}/{p2}")]
        public HttpResponseMessage Get (string p1, string p2) {
        ...
        }
    }
