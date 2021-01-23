        public ActionResult Partial()
        {
            var viewModel = new SearchViewModel();
        
            viewModel.SearchObjectTypes.Add(new SelectListItem { Text = "Please select...", Value = "" });
            viewModel.SearchObjectTypes.Add(new SelectListItem { Text = "Dog", Value = "Dog" });
            viewModel.SearchObjectTypes.Add(new SelectListItem { Text = "Person", Value = "Person" });
        
            return View(viewModel);
        }
    
    public ActionResult GetDogSearchView()
    {
        if (Request.IsAjaxRequest())
        {
            return PartialView("_DogSearch");
        }
    
        return View("_DogSearch");
    }
