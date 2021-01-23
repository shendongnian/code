    public abstract class _baseController : Controller
    {
        public ActionResult ActionThatDoesNotNeedToBeOverridden()
        {
            ...
            return View();
        }
        
        public virtual ActionResult Foo()
        {
            ...
            return View();
        }
    }
    
    public class FooController : _baseController
    {
        [Route("foo", Name = "Foo")]
        public override ActionResult Foo()
        {
            return base.Foo();
        }
    }
    
    public class BarController : _baseController
    {
        [Route("bar", Name = "Bar")]
        public override ActionResult Foo()
        {
            return base.Foo();
        }
    }
