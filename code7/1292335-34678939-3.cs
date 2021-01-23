	public class MyController : BaseController
	{
		public ActionResult DoSomeUserStuff()
		{
		}
		[OverrideCustomAuthorizeAttribute(Role = "Admin")]
		public ActionResult DoSomeAdminStuff()
		{
		}
	}
