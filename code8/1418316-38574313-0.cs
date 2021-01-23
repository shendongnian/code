    public class HomeController : Controller {
        IDummy dummy;
        public HomeController(IDummy dummy) {
            this.dummy = dummy
        }
    
        public IActionResult Index(){
            var test = dummy.name;
            return this.View(HomeControllerAction.Index);
        }
    }
