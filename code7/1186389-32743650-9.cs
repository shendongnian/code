    public class HomeController : Controller
    {
        private string _token;
        public HomeController(IOptions<AppSettings> settings)
        {
            _token = settings.Options.token;
        }
    }
