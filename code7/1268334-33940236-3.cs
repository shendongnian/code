    [HttpPost]
    public ActionResult Edit([Bind(Include = "id,s1,s2")] Class1 class1)
    {           
        db.Entry(class1).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index");
    }
