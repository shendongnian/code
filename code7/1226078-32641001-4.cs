	[ApiExceptionAttribute("This end point is to test error!")]
    public class TestController : ApiController
    {
        public IEnumerable<string> Get()
        {
			//actual code here
            throw new Exception("Back-end exception");
        }
	}
