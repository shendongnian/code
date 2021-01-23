    public ActionResult NameOfAction(NameOfViewModel model)
    {
        if (model.PussibleManager = 0)
        {
            ModelState.AddModelError("PussibleManager", "ErrorMessageHere");
        }
        if (ModelState.IsValid)
        {
           // DO SOMETHING HERE
        }
        return View(model);
    }
