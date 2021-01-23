    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new MyModel();
            model.AllItems = new List<SelectListItem>
            {
                new SelectListItem { Text = "One",  Value = "1"},
                // *** Option two is selected by default ***
                new SelectListItem { Text = "Two",  Value = "2", Selected = true},
                new SelectListItem { Text = "Three",  Value = "3"}
            };
            return View(model);
        }
    
        [HttpPost]
        public ActionResult Index(MyModel model)
        {
            // Get the selected value
            int id = model.SelectedId;
            return View();
        }
    }
