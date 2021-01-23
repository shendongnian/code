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
    		public string SetAllStatusRules([FromBody]string ruleList)
    		{
    			SystemStatusRules subjectRules = 
    				JsonConvert.DeserializeObject<SystemStatusRules>(ruleList);
    			return ruleList;
    		}
    	}
    }
