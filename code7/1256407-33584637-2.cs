    if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
    {
        throw new Exception("Invalid username and password");
    }
    var context = new InventoryManagerEntities();
    return (from usr in context.Users
            where usr.usr_Username == username 
               && usr.usr_Password == password
            select usr).FirstOrDefault();
