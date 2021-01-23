    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new HomeModel
            {
                AvailableFruits = GetFruits()
            };
            return View(model);
        }
    
        [HttpPost]
        public ActionResult Index(HomeModel model)
        {
            if (ModelState.IsValid)
            {
                var fruits = string.Join(",", model.SelectedFruits);
    
                // Save data to database, and redirect to Success page.
    
                return RedirectToAction("Success");
            }
            model.AvailableFruits = GetFruits();
            return View(model);
        }
    
        public ActionResult Success()
        {
            return View();
        }
    
        private IList<SelectListItem> GetFruits()
        {
            return new List<SelectListItem>
            {
                new SelectListItem {Text = "Apple", Value = "Apple"},
                new SelectListItem {Text = "Pear", Value = "Pear"},
                new SelectListItem {Text = "Banana", Value = "Banana"},
                new SelectListItem {Text = "Orange", Value = "Orange"},
            };
        }
    }
