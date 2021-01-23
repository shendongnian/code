    [TokenAuthorizationFilter]
    public class HomeController : AjaxBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
