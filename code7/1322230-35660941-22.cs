    public class MyController : Controller
    {
        ... same as in OP
        [HttpPost]
        public IActionResult Index([FromServices]MyViewModel model)
        {
            return View(model);
        }
    }
