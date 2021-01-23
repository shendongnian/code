    [Authorize(Roles = "Admin")]
    public ActionResult DeleteUser()
    {
         ViewData["UserList"] = getUsers();       
         return View();
    }
