    public class HomeController : Controller
    {
        private string _title;
        private string _fromNumber;
        private int _maxRetries;
        public HomeController(IOptions<AppSettings> settings)
        {
            _title = settings.Options.SiteTitle;
            _fromNumber = settings.Options.Sms.FromNumber;
            _maxRetries = settings.Options.Dms.MaxRetries;
        }
