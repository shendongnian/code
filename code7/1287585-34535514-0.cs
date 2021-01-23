    [RoutePrefix("api")]
    public class TestController : ApiController
    {
        [HttpGet]
        public string Index()
        {
            return "Service is running normally...";
        }
    }
