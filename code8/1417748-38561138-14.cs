    public class MyController : Controller {
        IMyContext _context;
        public MyController(IMyContext context) {
            _context = context;
        }
    
        public IActionResult Index() {
            SettingsViewModel svm = _context.MySettings(User.Identity.Name);
            return View(svm);
        }
          
        //...other code removed for brevity 
    }
