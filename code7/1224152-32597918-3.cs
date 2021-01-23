    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(SkillSetsModel model)
    {
      if (!ModelState.IsValid)
      {
        // Return the view so the user can correct errors
        ViewBag.Campaign = ... // as per the GET method
        return View(model);
      }
      db.SkillSets.Add(ss);
      db.SaveChanges();
      return RedirectToAction("Index");
    }
