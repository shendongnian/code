    public ActionResult Create(int? id)
    {
      OptionVM model = new OptionVM
      {
        Lsystem = id // set the parent
      };
      ConfigureViewModel(model);
      return View(model);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(OptionVM model)
    {
      if (!ModelState.IsValid)
      {
        ConfigureViewModel(model);
        return View(model);
      }
      Option option = new Option
      {
        OptionName = model.Name,
        TCID = model.TC,
        LsystemID= model.Lsystem
      };
      db.Option.Add(option);
      db.SaveChanges();
      return RedirectToAction("Index");
    }
    private void ConfigureViewModel(OptionVM model)
    {
      model.TCList = new SelectList(db.TC, "TCID", "TCName");
    }
