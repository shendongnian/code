    Db1Context c1 = new Db1Context();
    var userToUpdateWith = c1.Users.Single(u => u.User == "Geekguy123")
    Db2Context c2 = new Db2Context();
    var userToUpdate = c2.Users.Single(u => u.User == "Geekguy123")
    userToUpdate.FirstName = userToUpdateWith.FirstName
    
