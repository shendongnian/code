    [HttpPost]
    public ActionResult DeleteUser(int id)
    {
        UsersContext deleteUser = new UsersContext();
        deleteUser.Delete(id);
        return RedirectToAction("Index");
    }
