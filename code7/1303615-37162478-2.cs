    public class SomeController : Controller
    {
        private readonly IOptions<MyConfiguration> config;
        public ServiceLocatorController(IOptions<MyConfiguration> config)
        {
            this.config = config;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return new HttpOkObjectResult(config.Value);
        }
    }
