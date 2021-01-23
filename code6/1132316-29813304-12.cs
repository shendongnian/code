    // Returns a partial view with a form to create a new Tag
    [ChildActionOnly]
    public ActionResult CreateTag()
    {
      Tag model = new Tag();
      return PartialView(model);
    }
    [HttpPost]
    public ActionResult CreateTag(Tag model)
    {
      // Save the Tag
      db.Tags.Add(model);
      db.SaveChanges();
      return Json(new { ID = model.Id, Name = model.Name });
    }
