    public class HomeController : UxController
    {
         public ActionResult Index()
         {
               return View();
         }
    
         public ActionResult SubmitForm(string message)
         {
              return WithResponse(RedirectToAction("Index"), "Thank you for feedback.");
         }
    }
