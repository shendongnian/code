    public class LayoutController : Controller
    {
    	private readonly IProvideData _provider;
    
    	public LayoutController(IProvideData provider)
    	{
    		_provider = provider;
    	}
    
    	[ChildActionOnly]
    	public ActionResult AccountInformation()
    	{
    		var model = _provider.GetUserStuff();
    		return PartialView("_AccountInformation", model);
    	}
    }
