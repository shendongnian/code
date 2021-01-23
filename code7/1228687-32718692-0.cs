    if (ModelState.IsValid)
    {
        using (var db = new MyDbContext())
        {
            db.Sammantrade.Add(sammantrade);
            db.SaveChanges();
            return RedirectToAction("Index");
        } // the using block will dispose of the DbContext here.
    }
