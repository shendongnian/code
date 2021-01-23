    public class SomeController : Controller
    {
    	[AuthorizedFilter]
    	public ActionResult Index()
    	{
    		return View();
    	}
    }
