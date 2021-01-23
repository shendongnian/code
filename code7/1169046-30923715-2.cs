    [Authorize(Roles = "Admin")]
    [HttpGet]
    public ActionResult DeleteUser()
    {
         var model = new DeleteUserViewModel{
            UserList = getUsers()
         };      
         return View(model);
    }
    [HttpPost]
    public ActionResult DeleteUser(DeleteUserViewModel model)
    {
         int userToDelete = model.SelectedUserId;
         //delete user logic here
    }
