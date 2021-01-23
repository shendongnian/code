    public class MyController : Controller
    {
        private readonly IAppConfiguration config;
        public MyController()
            : this(new AppConfiguration(HttpContext.Current))
        {
        }
        public MyController(IAppConfiguration config)
        {
            this.config = config;
        }
        // reference config.ServerPath or config.MyConnectionString;
    }
