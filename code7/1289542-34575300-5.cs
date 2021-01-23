    public class HomeController : Controller
    {
    	private IDatabase Database;
    
    	public HomeController()
    	{
    		this.Database = new Database();
    	}
    
    	[HttpGet]
    	public ActionResult Verify(string id)
    	{
    		using(this.Database)
    		{
    			if (Database.VerifyUser(id))
    			{
    				return View();
    			}
    			else
    			{
    				ViewBag.Error = "There was an error with the verification process";
    				return View();
    			}
    		}
    	}	
    }
