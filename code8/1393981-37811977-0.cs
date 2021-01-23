     public class HomeController : Controller
        {
            [HttpPost]
            public ActionResult Index(FormCollection formCollection)
            {
                    var value = formCollection["nameOfControl"];
                    //do stuff
                    return View();
                }
