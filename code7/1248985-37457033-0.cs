    // GET: Roles
    public ActionResult AllRoles()
    {
       return View(db.Roles.ToList());
    }
