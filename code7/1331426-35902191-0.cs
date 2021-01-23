    var user = new User { Name = "Mike", Code = 12 };
    uow.Users.Add(user);
    uow.Commit();  // save first time
    if (user.Code > 10)
    {
        var newUser = new User { Name = "NAS", Code = user.Code };
        uow.Users.Add(newUser);
        uow.Commit(); //save second time
    }
