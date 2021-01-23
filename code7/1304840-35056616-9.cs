    public class HomeController : Controller
    {
    	public ActionResult Index()
    	{
    		return this.View();
    
    	}
    
    	[HttpPost]
    	public JsonResult SavePlace(Company company)
    	{
    		if (company != null)
    		{
    
    			return Json(new { data = "fine." });
    		}
    		else
    		{
    			return Json(new { data = "error." });
    		}
    	}
    }
    
    public class Company
    {
    	public String PlaceId { get; set; }
    
    	public string Name { get; set; }
    
    	public string Email { get; set; }
    
    	public Double Rating { get; set; }
    
    	public object Department { get; set; }
    
    	public object Product { get; set; }
    
    	public Comment[] Comments { get; set; }
    }
    
    public class Comment
    {
    	public String Text { get; set; }
    }
