    public ActionResult Edit()
    {
      List<OptionVM> model = new List<OptionVM>();
      .... // populate it
      return View(model);
    }
