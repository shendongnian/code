    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Update(int ID)
    {
      // Get the model
      TaskItem model = db.TaskItems.Where(m => m.ID == ID).FirstOrDefault();
      // Update properties
      model.timestamp = DateTime.UtcNow;
      model.applied_by = System.Web.HttpContext.Current.User.Identity.Name;
      model.status = "Done";
      // Save and redirect
      db.Entry(model).State = EntityState.Modified;
      db.SaveChanges();
      return RedirectToAction("Index");
    }
