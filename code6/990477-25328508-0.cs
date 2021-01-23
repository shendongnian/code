    [RoutePrefix("{Type:regex(Foo|Bar)}")]
    public class FooController : Controller
    {
        [Route("foo", Name = "Foo")]
        public virtual ActionResult Foo()
        {
            ...
            return View();
        }
    }
