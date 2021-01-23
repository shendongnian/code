    [RoutePrefix("api")]
    public class api: ApiController {
        [HttpGet]
        [Route("Supressions")]
        public HttpResponseMessage Get(HttpRequestMessage request, string abc, int id, int somethingElse){
          ///etc
        }
    }
