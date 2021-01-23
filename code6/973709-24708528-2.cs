	public class HomeController : Controller
	{
		public ActionResult Index(string message)
		{
			ViewBag.Message = message;
			return View();
		}
		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";
			return View();
		}
	}
