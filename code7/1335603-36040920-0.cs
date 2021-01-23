    public class SearchController : Controller
    {
    	[HttpPost]
    	public ActionResult SearchForAccounts(string[] accounts)
    	{
    		var searchResults = db.Search(accounts);
    
    		return View('ResultsView', searchResults);
    	}
    }
