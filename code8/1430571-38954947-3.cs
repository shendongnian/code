    //perform string search
    DbContext.Users.Any(u=>u.Username == SearchString);
    //perform ID search
    DbContext.Users.Find(UserID);
    //Add new users
    DbContext.Users.Add(new User(){//populate details});
    DbContext.Save();
