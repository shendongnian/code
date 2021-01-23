    public class FooController : Controller
    {
        ...
        [ChildActionOnly]
        public ActionResult SiteMenu()
        {
            // load menu items however you need to
            return PartialView("_SiteMenu", menuModel);
        }
    }
