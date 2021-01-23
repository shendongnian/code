    [HttpPost]
    public ActionResult Index(FiltersViewModel viewModel)
    {       
       if (ModelState.IsValid)
       {
          var test = viewModel.FacilityList;
          //State of checkboxes is not correct at this point.
       }
     }
