    public class YourController : Controller
    {
    public ActionResult Index()
     {
            var model = YourDataToDisplay;
    
            return View(model);
     }
    public ActionResult ControllerAction(int sales)
    {
        //.....
    }
    }
