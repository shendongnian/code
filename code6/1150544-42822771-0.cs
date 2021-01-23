    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Modify(Model model)
    {
    if (model.Image == null)
    {
    Model item = db.Model.Find(model.Name);
    // Get the Content needed:
    model.Image = item.Image;
    // Detach the Comparison State:
    db.Entry(item).State = EntityState.Detached;
    }
    if (ModelState.IsValid)
    {
    db.Entry(model).State = EntityState.Modified;
    db.SaveChanges();
    return RedirectToAction("Index");
    }
    return View(model);
    }
