    namespace HelloWorldMvcApp
    {
    	public class HomeController : Controller
    	{
    		[System.Web.Mvc.HttpGetAttribute]
    		public ActionResult Index()
    		{
    			return View();
    		}
    
    		[System.Web.Mvc.HttpPost]
    		public string SetAllStatusRules(string ruleList)
    		{
    			SystemStatusRules subjectRules = 
    				JsonConvert.DeserializeObject<SystemStatusRules>(ruleList);
			    return subjectRules.EmailItems[0].Email_String;
    		}
    	}
    }
