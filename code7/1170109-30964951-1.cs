    [Route("v1/[controller]")]
    public class UsersController : Controller
    {
        [HttpGet("{id:int}")]
        public IActionResult Users(long id)
        {
            return Json(new { name = "Example User" });
        }
        public IActionResult Users()
        {
            return Json(new { list = new[] { "a", "b" } });
        }
    }
