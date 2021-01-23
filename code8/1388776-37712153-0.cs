    public class CustomFooController : MyProject.Areas.Foo.Controllers.FooController
    {
        [Route("Foo/Bar")]
        public ActionResult Bar()
        {
            return Content("Bar");
        }
    }
