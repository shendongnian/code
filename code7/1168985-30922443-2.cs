    [HttpPost]
    public ActionResult Index(FiltersViewModel viewModel)
    {       
       if (ModelState.IsValid)
       {
          var test = viewModel.FacilityList;
       }
     }
