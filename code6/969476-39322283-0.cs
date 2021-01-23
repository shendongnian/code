    public class ValuesController : Controller
    {
        private IHostingEnvironment _env;
        public ValuesController(IHostingEnvironment env)
        {
            _env = env;
        }
        public IActionResult Get()
        {
            var webRoot = _env.WebRootPath;
            var file = Path.Combine(webRoot, "test.txt");
            File.WriteAllText(file, "Hello World!");
            return OK();
        }
    }
