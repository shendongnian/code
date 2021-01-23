public class HomeController : CustomController
    public ActionResult Brochure(string id, string action) {
        if (ViewExists(id)) {
            return View(id);
        }
    
        return RedirectToAction("Index", "Home", new { client = id, action = "Index" });
        //return RedirectToRoute("HomeDefault", new { client = id, category = 1 });
    }
