    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new MyModel();
            model.AllItems = new List<SelectListItem>
            {
                new SelectListItem { Text = "One",  Value = "1"},
                new SelectListItem { Text = "Two",  Value = "2"},
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
