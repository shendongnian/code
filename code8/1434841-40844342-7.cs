    public class HomeController : Controller
    {
        public SmtpConfig SmtpConfig { get; }
        public HomeController(Microsoft.Extensions.Options.IOptions<SmtpConfig> smtpConfig)
        {
            SmtpConfig = smtpConfig.Value;
        } //Action Controller
        public IActionResult Index()
        {
            System.Console.WriteLine(SmtpConfig);
            return View();
        }
