    public class AboutController : BaseController
    {
        public ActionResult Index()
        {
            //create instance for About Model
            var model = new AboutModel();
            Intialize(model);
            model.AboutDescription = "About Description";
    
            return View(model);
        }
    }
