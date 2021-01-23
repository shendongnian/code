    public class TestController : Controller
    {
        IPersonService _service;
        public TestController(IPersonService service)
        {
            _service = service;
        }
    }
