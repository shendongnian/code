    public class SearchController : Controller
    {
    	public ActionResult SearchForAccounts(string[] accounts)
    	{
    		var searchResults = db.Search(accounts);
    
    		return View('ResultsView', searchResults);
    	}
    }
