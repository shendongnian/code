	[CheckForLogout] // You can add it to specific controller(s)
    public class HomeController : Controller
    {
		[CheckForLogout] // Or you can do it only on certain action(s)
        public ActionResult Index()
        {
			return View();
        }
	}
	
