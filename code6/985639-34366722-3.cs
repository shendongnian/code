    [RoutePrefix("version1")]
    public class ValuesController : ApiController {
        [Route("api/base")]
        public virtual HttpResponseMessage GetBaseMethod() {
            return Request.CreateResponse("bbb");
        }
    
        [Route("api/values")]
        public virtual HttpResponseMessage GetVersion1() {
            return Request.CreateResponse("aaa");
        }
    }
    
    [RoutePrefix("version2")]
    public class Values2Controller : ValuesController {
        
        public override HttpResponseMessage GetVersion1() {
            return Request.CreateResponse(5);
        }
    }
