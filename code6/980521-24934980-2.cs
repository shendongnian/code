    	public class SystemController : Controller {
    		private SigoContext db = new SigoContext();
    
    		[ChildActionOnly]
    		public ActionResult TopMenu() {
    			return PartialView("TopBar",db.TopMenu);
    		}
       	}
