    [HttpPost]
    public ActionResult Edit(int id, Foo model)
    {
        var foo = db.Foos.Find(id);
        if (foo == null)
        {
            return new HttpNotFoundResult();
        }
        if (ModelState.IsValid)
        {
            // map values from model (posted data) to instance from DB
            db.Entry(foo).State = EntityState.Modified;
            db.SaveChanges();
        }
        return View(model);
    }
