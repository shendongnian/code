    public class MyController : Controller
    {
      public ActionResult Search(string q)
      {
        ViewBag.Query = q;
        return View("~/Views/Search.cshtml");
      }
    }
