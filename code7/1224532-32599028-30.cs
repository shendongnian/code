    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var provider = new EncryptionProvider();
            await provider.GetKeyBundle();
            var x = provider.MyKeyBundle;
            return View();
        }
    }
