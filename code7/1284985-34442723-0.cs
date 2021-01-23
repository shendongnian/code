    namespace MyApp.Controllers
    {
        public class RegistrationController : Controller
        {
            private RegistrationService registrationService;
    
            public RegistrationController()
            {
                this.registrationService = new RegistrationService();
            }
    
            public ActionResult Index()
            {
                ViewBag.Title = "Registration Page";
    
                return View();
            }
        }
    }
