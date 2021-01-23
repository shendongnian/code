    public User GetUser(string username, string password)
    {
        User user = new User(); // <= user is only initialized
        try
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                throw new Exception("Invalid username and password");
            }
            var context = new InventoryManagerEntities();
            var userContext = // <= should be "user", not "var userContext"
                (from usr in context.Users
                    where usr.usr_Username == username 
                       && user.usr_Password == password // <= should be usr.usr_Password
                    select usr).FirstOrDefault();
        }
        catch (Exception)
        {
            throw;
        }
        return user;
    } 
