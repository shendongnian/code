    public class HomeController : Controller
    {
        protected ILogger Logger { get; }
        public HomeController(ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
        {
            Logger = loggerFactory.CreateLogger(GetType().Namespace);
            Logger.LogInformation("created homeController");
        }
