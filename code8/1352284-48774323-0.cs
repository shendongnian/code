    [Route("/api/[controller]")]
    public class TestController: Controller
    {
        [Route("test")]
        [HttpGet]
        public string Test()
        {
            return "Hello";
        }
    }
