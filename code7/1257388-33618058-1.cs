    public class Account Controller : Controller
	{
		public ActionResult SwitchByName(string accountName)
		{
			ViewBag.Title = "Account name: "+ accountName;
			return View();
		}
	}
