    public class DataController : Controller
    {
        public ActionResult Index()
        {
            string data = System.IO.File.ReadAllText(@path);
            var model = ConvertDataToModelSomehow(data); //model variable type: Global 
            return View(model);
        }
    }
