    public class HomeController : Controller
    {
     public ActionResult AddArticle()
     {
     return View();
     }
     
     [ValidateInput(false)]
     [HttpPost]
     public ActionResult AddArticle(BlogModel blog)
     {
     if (ModelState.IsValid)
     {
     
     }
     return View();
     }
    }
