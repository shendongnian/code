    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            MYvm vm = new MYvm() { id = 1, name = "This is my View Model" };
         
            return View(vm);
        }
        public ActionResult DA(MYvm vm)
        {
            vm.name = "CHANGED";
            return PartialView("Part", vm);
        }
