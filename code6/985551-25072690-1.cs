    public ActionResult Details()
    {
      CombinedViewModel model = new CombinedViewModel();
      // set properties
      model.MajorVM = new MajorVM();
      model.MajorVM.Majors = // assign your collection
      ..
      return View(model);
    }
