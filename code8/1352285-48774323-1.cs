    [Route("/api/[controller]/[action]")]
    public class TestController: Controller
    {
        [HttpGet]
        public string Test()
        {
            return "Hello";
        }
    }
