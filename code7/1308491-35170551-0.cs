    namespace namespaceName.Controllers
    {
    	public class ControllerName : Controller
        {
    		public ActionResult firstController()
            {
    			var data = TempData["data"].ToString();
    		}
    		public ActionResult secondController()
            {
    			TempData["data"] = "data";
    			return RedirectToAction("firstController");
    		}
    	}
    }
