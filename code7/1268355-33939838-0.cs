    public ActionResult HomeAction(Address model)
    {
       if (string.IsNullOrEmpty(model.AD))
       {
          ModelState.AddModelError(string.Empty, "Home AD is required");
          return View(model);
       }
       // model.AD is valid here...
       return View();
    }
    
    public ActionResult WorkAction(Address model)
    {
       if (string.IsNullOrEmpty(model.AD))
       {
          ModelState.AddModelError(string.Empty, "Work AD is required");
          return View(model);
       }
       // model.AD is valid here...
       return View();
    }
