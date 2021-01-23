    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Phone ph, string Caller)
    {
        if (ModelState.IsValid)
        {
            ph.Active = true;
            db.PhoneBook.Add(ph);
            db.SaveChanges();
        return Json(new { success = true, redirecturl = Url.Action("RedirectedAction") });
    }
