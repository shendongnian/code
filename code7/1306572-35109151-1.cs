    public ActionResult Index()
    {
       var userList= db.Users.Select(s=> new UserViewModel {
                                      UserName =s.UserName,
                                      Description=s.Description..ToSafeSubString(10) })
                                  .ToList();
       return View(userList);
    }
