    public ActionResult Save(CreateMessageViewModel model)
    {
      bool exists = // check the existence of RecipientUsername
      if (!exists)
      {
        ModelState.AddModelError("RecipientUsername ", "The user does not exist");
      }
      if (!ModelState.IsValid)
      {
        return View(model);
      }
      // all good
    }
