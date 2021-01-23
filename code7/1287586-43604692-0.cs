    public class TestController : ApiController
    {
    
        [Route(""), HttpGet]
        public string Index()
        {
             return "Service is running normally...";
        }        
    }
