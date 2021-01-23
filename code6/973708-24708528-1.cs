	public class HomeController : Controller
	{
		const string SomeMessage = "Your application description page.";
		public ActionResult Index()
		{
			ViewBag.Message = SomeMessage;
			return View();
		}
		public ActionResult About()
		{
			ViewBag.Message = SomeMessage;
			return View();
		}
	}
