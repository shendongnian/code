	public class LoginController : Controller
	{
		[Route("user/{user}", Name = "first")]
		public ActionResult Index(string user)
		{
			return View();
		}
		[Route("company/{company}", Name = "second")]
		public ActionResult Index2(string company)
		{
			return View();
		}
	}
