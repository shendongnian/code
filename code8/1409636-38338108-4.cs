    [HttpPost]
    public ActionResult Index(ViewModel viewModel)
    {
      // just some crude model state checking..
      if(!ModelState.IsValid)
      {
         return View(ModelState.Values);
      }
    
      ViewBag.ListBox1Selected = viewModel.SelectedListItems1;
      ViewBag.ListBox2Selected = viewModel.SelectedListItems2;
    
      // just reusing our load helper method here passing in the viewModel obj
     //  from the post..
      var vwModel = LoadViewModel(viewModel);
    
      return View(viewModel);
    }
