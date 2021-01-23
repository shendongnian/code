    public class SomeController : Controller
    {
        [HttpPost]
        public async Task<ActionResult> Foo()
        {
            Response.StatusCode = 400;
            return Content("Naughty");
        }
    }
