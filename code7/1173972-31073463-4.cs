    public class HomeController : Controller
    {
           [InvitationModeAttribute]
         public ActionResult Index()
         {            
            return View();
         }
     }
