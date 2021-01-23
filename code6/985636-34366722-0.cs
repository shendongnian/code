    [RoutePrefix("version1")]
    public class ValuesController : ApiController {
        [Route("api/base")]
        public string GetBaseMethod() {
            return "bbb";
        }
    
        [Route("api/values")]
        public virtual object GetVersion1() {
            return "aaa";
        }
    }
    
    [RoutePrefix("version2")]
    public class Values2Controller : ValuesController {
    
        public override object GetVersion1() {
            return 5;
        }
    }
