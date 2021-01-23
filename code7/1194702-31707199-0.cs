    public class HomeController : Controller
    {
        private IFooService service;
        public HomeController()
        {
            this.service = new FooService(dbContext);
        }
        public ActionResult CalculateFoo(int id)
        {
            var foo = this.service.CalculateFoo(id);
            return View(foo);
        }
    }
    public class FooController : Controller
    {
        private IFooService service;
        public FooController()
        {
            this.service = new FooService(dbContext);
        }
        public ActionResult Details(int id)
        {
            var foo = this.service.CalculateFoo(id);
            return View(foo);
        }
    }
