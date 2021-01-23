    if (ModelState.IsValid)
    {
        using (var db = new MyDbContext())
        {
            db.Sammantrade.Add(sammantrade);
            db.SaveChanges();
        } // the using block will dispose of the DbContext here.
        return RedirectToAction("Index");
    }
