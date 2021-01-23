    public ActionResult Create()
    {
        ViewBag.roleID = new SelectList(database.Role, "ID", "text");
        return View()
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "ID, firstName, lastName, enrollmentDate, departmentID, depotID, roleID")] User user)
    {
        ViewBag.roleID = new SelectList(database.Role, "ID", "text", user.roleID);
        return View(user);
    }
