    public class MyController : Controller
    {
        public ActionResult MyAction()
        {
            //you can access this.Request.Browser 
            //because "this" gives an instance of Controller
            //you can't use System.Web.Mvc.Controller.Request.Browser 
            //because "Request" is not a static property of "Controller"
        }
    }
