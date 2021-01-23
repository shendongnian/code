    public ActionResult Create()
    {
      ViewBag.Campaign = db.Categories.Where(c => c.Active == 1).Select(c => new SelectListItem
      {
        Value = c.IDCategory.ToString(),
        Text = c.Name
      });
      return View(new SkillSetsModel()); // always return a model
    }
