    var user = new User { Name = "Mike", Code = 12 };
    uow.Users.Add(user);
    uow.Commit();  // save first time
    if (user.Code > 10)
    {
        uow.Entry(user).State = EntityState.Detached;
        user.Id = 0;
        user.Name = "NAS";
        uow.Users.Add(user);
        uow.Commit(); //save second time
    }
