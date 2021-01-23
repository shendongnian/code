    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "Id,Name,LastName,Birthdate,Club")] Player player) {
        if (ModelState.IsValid) {
            db.Players.Add(player);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return RedirectToAction("Create", player);
    }
