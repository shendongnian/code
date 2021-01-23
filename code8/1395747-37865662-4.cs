    public class ValuesController : ApiController {
        //GET api/values/100/some-string-here
        [HttpGet]
        [Route("api/values/{p1}/{p2}")]
        public HttpResponseMessage Get (string p1, string p2) {
        ...
        }
    }
