    public class TestController : Controller
    {
        ...
        [HttpPost]
        public ActionResult SaveAndSend(YourModel model)
        {
             if (ModelState.IsValid)
             {
                 // Some magic with your data
                 return RedirectToAction(...);
             }
             return View(model); // As an example
        }
        ...
    }
