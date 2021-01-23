    public class HomeController
    {
        private string _title;
        public HomeController(IOptions<AppSettings> settings) 
        {
            _title = settings.Options.SiteTitle;
        }
    }
