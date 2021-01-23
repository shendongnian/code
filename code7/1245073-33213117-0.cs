    try
    {
        var user = entities.Users.SingleOrDefault(u => u.Username.Equals(username));
    }
    catch
    {
        // handle the case when there are more than 
        // one user with given name in DB
    }
