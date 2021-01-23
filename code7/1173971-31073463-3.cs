     public class ServiceController : Controller
     {
       [InvitationModeAttribute]
       public ActionResult Confirm()
       { 
         return RedirectToAction("Index", "Home");
       }
     }
