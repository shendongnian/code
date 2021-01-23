    public class HomeController : Controller
    {
        [ActionName("Bar")]
        public ActionResult MyActionMethod()
        {
            return Content("Foo");
        }
        [MyActionSelector]
        [ActionName("Foo")]
        public ActionResult Foo()
        {
            return Content("Foo");
        }
        [MyActionSelector]
        [ActionName("Foo")]
        public ActionResult Foo2()
        {
            return Content("Foo2");
        }
    }
