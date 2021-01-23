    public class ExampleController : Controller
    {
        // this is syntacically not correct
        public IActionResult Collection(...., [FromQuery(Name = "$orderBy")]string orderBy = null)
        {
             ...
        }
    }
