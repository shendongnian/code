    public class MenuController : Controller
    {
      [ChildActionOnly]
      public ActionResult Index()
      {
        // Build your menu model;
        return PartialView(model);
      }
    }
