    [HttpPost]
    public ActionResult InsertNewRecord(MyModel model)
    {
      if (model.IsValid)
      {
        db.tblProfile.Add(model);
        db.SaveChanges();
      }
      return RedirectToAction("Index");
    }
---
    public ActionResult UpdateRecord(MyModel model)
    {
      if (model.IsValid)
      {
        db.Entry(model).State = EntityState.modified;
        db.SaveChanges();
      }
      return RedirectToAction("Index");
    }
