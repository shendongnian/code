    public ActionResult Edit(int id)
    {
        Class1 class1 = db.Class1.Find(id);
        return View(class1);
    }
