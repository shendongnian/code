    public async Task<ActionResult> Edit([Bind(Include = "Id,aDefault,Name")] MyObject myObject)
    {
        if (ModelState.IsValid)
        {
            db.MyObjects.Attach(myObject); //MyObjects is the DbSet
            myObject.dateModified = DateTime.Now;
            db.Entry(myObject).Property(o => o.Name).IsModified = true;
            db.Entry(myObject).Property(o => o.aDefault)IsModified = true;
            await db.SaveChangesAsync(); //db is the generated dbcontext
            return RedirectToAction("Index");
        }
        return View(myObject);
    }
