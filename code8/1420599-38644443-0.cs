    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Save(string name)
        {
            if(String.IsNullOrEmpty(name))
                TempData["sErrMsg"] = "Product name cannot be empty";
            return View("Index");
        }
        public PartialViewResult ShowError(String sErrorMessage)
        {
            return PartialView("ErrorMessageView");
        }
    }
