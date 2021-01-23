    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Index([Bind(Include = "id,email")] user user)
    {
        var username = HttpContext.User.Identity.Name;
        if (ModelState.IsValid)
        {
            var userChange = db.profiels.Single(x => x.id == user.id);
            userChange.email = user.Email;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(user);
    }
