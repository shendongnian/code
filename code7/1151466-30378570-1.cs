    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit([Bind(Include = "ID,Name,Value")]     ConfigOption model)
    {
      if (ModelState.IsValid)
      {
         var config=db.Configs.Find(model.ID);
         config.Value=model.Value;
         await db.SaveChangesAsync();
         return RedirectToAction("Index");
      }
      return View(config);
    }
