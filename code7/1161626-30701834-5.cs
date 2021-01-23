    public ActionResult SelectUser()
    {
      SelectUserVM model = new SelectUserVM();
      model.AllUsers = db.Users; // adjust to suit
      return View(model);
    }
    [HttpPost]
    public ActionResult SelectUser(SelectUserVM model)
    {
      int selectedUser = model.SelectedUser;
    }
