    [Route("foo")]
    public class FooController : Controller
    {
        [Route("bar")] // combined with "foo" to map to route "/foo/bar"
        public IActionResult Bar()
        {
            // ...
        }
        [Route("/hello/world")] // not combined; maps to route "/hello/world"
        public IActionResult HelloWorld()
        {
        }   
    }
