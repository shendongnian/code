    public class FooController : Controller
    {
        ...
        [ChildActionOnly]
        public ActionResult DisplayBaseInfo()
        {
            var baseInfo = new BaseInfo(); // pull from database or construct the instance however you like here
            return PartialView("_DisplayBaseInfo", baseInfo);
        }
    }
