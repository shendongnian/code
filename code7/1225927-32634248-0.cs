    [ValidateInput(false)]
    public class HomeController : Controller
    {
     public ActionResult AddArticle()
     {
     return View();
     }
     
     [HttpPost]
     public ActionResult AddArticle(BlogModel blog)
     {
     if (ModelState.IsValid)
     {
     
     }
     return View();
     }
    }
