    class myController : Controller
    {
         ActionResult Index()
         {
             If(someCheck)
             {
                  return RedirectToAction("ErrorView");
             }
             return View();
         }
         ActionResult ErrorView()
         {
             return View();
         }
    }
