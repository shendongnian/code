    public class ExampleController : Controller
    {        
        public IActionResult Collection(...., [FromQuery(Name = "$orderBy")]string orderBy = null)
        {
             ...
        }
    }
