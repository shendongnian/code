    [HttpPost]
    public ActionResult Saving(Language lan)
    {
        db.Languages.Add(lan);
        db.SaveChanges();
        return View(db.Languages.ToList());
    }
