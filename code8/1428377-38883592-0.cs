    [RoutePrefix("api")]
    public class api: ApiController {
        [HttpGet]
        [Route("Supressions")]
        public HttpResponseMessage GetAll(){
          ///etc
        }
    }
