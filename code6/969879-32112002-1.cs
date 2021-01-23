    using Foobar.Common.Extensions;
    
    namespace Foobar.Web.Main.Controllers
    {
    	public static HomeController 
    	{
    		public ActionResult Index()
    		{
                // add/updating claims
    		    User.AddUpdateClaim("key1", "value1");
    	        User.AddUpdateClaim("key2", "value2");
    	        User.AddUpdateClaim("key3", "value3");
    		}
    
    		public ActionResult Details()
    		{
                // reading a claim
    			var key2 = User.GetClaim("key2");			
    		}
    	}
    }
