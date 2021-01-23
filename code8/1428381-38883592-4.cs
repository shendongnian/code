    [RoutePrefix("api")]
    public class api: ApiController {
        [HttpGet]
        [Route("Supressions/{abc}")]
        public HttpResponseMessage Get(HttpRequestMessage request, string abc){
          ///etc
        }
    }
