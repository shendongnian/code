    public class FooController : Controller
    {
        [Route("foo", Name = "Foo")]
        public virtual ActionResult Foo()
        {
            ...
    
        return View();
        }
    }
    
    public class BarController : FooController
    {
        [Route("bar", Name = "Bar")]
        public override ActionResult Foo()
        {
            return base.Foo();
        }
    }
