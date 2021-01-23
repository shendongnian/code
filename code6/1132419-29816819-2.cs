	public class LoginController : Controller
	{
		[Route("Login/Index/{user}", Name = "first")]
		public ActionResult Index(string user)
		{
			return View();
		}
		[Route("Login/Index2/{company}", Name = "second")]
		public ActionResult Index2(string company)
		{
			return View();
		}
	}
