    [Authorize]
    public ActionResult Create()
    {
        ViewBag.UserList = new SelectList(db.Users, "Id", "Fullname");
        return View();
    }
