    [RoutePrefix("api")]
    public class api: ApiController {
        [HttpGet]
        [Route("Supressions/get")]
        public HttpResponseMessage Get(string abc, int id, int somethingElse){
          ///etc
        }
    }
