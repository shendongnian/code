        [HttpGet]
        public ActionResult Index()
        {
            var model = new MainViewModel();
            // populate the model with data here for the initial display, including the initial drop-down values, 
            // presumably the same way you do now
            // into model.QuestionTypeValues
            return View(model); // the main view
        }
        [HttpGet]
        public ActionResult PopulateType(int selectedValue) // could use an enum for the selectable values
        {
            var model = new QuestionViewModel();
            string partialViewName = null;
            // populate with data appropriate to the partial views
            switch (selectedValue)
            {
                case 0:
                    partialViewName = "partial view name for item 0";
                    // populate "model" with the appropriate data
                    break;
                case 1:
                    partialViewName = "partial view name for item 1";
                     // populate "model" with the appropriate data
                    break;
                // and so on...
                default:
                    throw new ArgumentException("unknown selected value", "selectedValue");
                    break;
            }
            
            return PartialView(partialViewName, model);
        }
