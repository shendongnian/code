    public class PreviewController : Controller
    {
        [HttpPost] // it seems you are using post method
        public ActionResult Index(string name, string rendering)
        {
            var information = new InformationClass();
            information.name = name;
            information.rendering = rendering;
            return View(information);
        }
    }
