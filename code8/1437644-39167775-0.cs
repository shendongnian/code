    public class TestController : Controller
    {
        public ActionResult Test()
        {
            var obj = new Foo();
            //Do some processing
            return View(obj);
        }
    }
