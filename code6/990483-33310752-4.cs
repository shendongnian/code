    public class _baseController : Controller
    {
        public ActionResult Foo()
        {
            ...
            return View();
        }
    }
    
    public class BarController : Controller
    {
        public ActionResult Bar()
        {
            var b = new _baseController();
            return b.Foo();
        }
    }
