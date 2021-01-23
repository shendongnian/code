    public class HomeController: Controller
    {
        public ActionResult Index()
        {
            var controller = (HomeController)this.MemberwiseClone();
            var list = ControllerContextClonable.ToList(controller);
            
            return View();
        }
    }
