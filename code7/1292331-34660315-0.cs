	public class MyController : BaseController
	{
		public ActionResult DoSomeUserStuff()
		{
		}
		[OverrideAuthorization(FiltersToOverride = typeof(CustomAuthorizeAttribute))]
		[CustomAuthorizeAttribute(Role = "Admin")]
		public ActionResult DoSomeAdminStuff()
		{
		}
	}
