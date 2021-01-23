    public class MyController : Controller {
        //...other code removed for brevity
    
        public IActionResult Index() {
            SettingsViewModel svm = _context.MySettings(User.Identity.Name);
            return View(svm);
        }    
    }
