    [Consumes("application/json")]
    public class MyController : Controller
    {
        public IActionResult MyAction([FromBody] CallModel model)
        {
            ....
        }
    }
