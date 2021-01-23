    // ProjectA is assumed to be your "main" MVC application
    public class CustomFooController :  ProjectA.Controllers.FooController
    {
        [Route("Foo/Bar")]
        public ActionResult Bar()
        {
            return Content("Bar");
        }
    }
