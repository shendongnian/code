    public ActionResult MyAction()
    {
      Temp viewModel = new Temp {
              Name = "Foo",
              Type = new Type() }
    
       return View(viewModel);
    }
