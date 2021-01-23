    public ActionResult Edit(string user_id)
    {
    ViewBag.USER_ID_MANAGER = new SelectList(db.APP_USERS, "USER_ID", "USER_ID");
                return View(app_users_manager);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(List<APP_USERS_MANAGER> app_users_manager)
    {
    return View(app_users_manager);
    }
