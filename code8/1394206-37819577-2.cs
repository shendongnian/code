    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new SampleModel
            {
                AvailableColors = GetColorListItems()
            };
            return View(model);
        }
    
        [HttpPost]
        public ActionResult Index(SampleModel model)
        {
            if (ModelState.IsValid)
            {
                var colorId = model.SelectedColorId;
                return View("Success");
            }
            // If we got this far, something failed, redisplay form
            // ** IMPORTANT : Fill AvailableColors again; otherwise, DropDownList will be blank. **
            model.AvailableColors = GetColorListItems();
            return View(model);
        }
    
        private IList<SelectListItem> GetColorListItems()
        {
            // This could be from database.
            return new List<SelectListItem>
            {
                new SelectListItem {Text = "Orange", Value = "1"},
                new SelectListItem {Text = "Red", Value = "2"}
            };
        }
    }
