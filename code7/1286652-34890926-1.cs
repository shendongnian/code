    public class RedirectController : Controller
    {
        public IActionResult Index()
        {
            return Redirect(Url.Content("~/"));
        }
    }
