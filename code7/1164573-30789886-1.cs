    public class StatusCodesController : Controller
    {
        public IActionResult StatusCode404()
        {
            return View(viewName: "NotFound"); // you have a view called NotFound.cshtml
        }
        ... more actions here to handle other status codes
    }
