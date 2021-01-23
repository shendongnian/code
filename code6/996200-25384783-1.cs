    public static void IncrementInvalidLoginColumn(string login)
    {
        User user;
        try
        {
            user = _context.Users.Where(u => u.Login.CompareTo(login) == 0).FirstOrDefault();
            if (user.InvalidLogins < 3)
            {
                user.InvalidLogins = user.InvalidLogins + 1;
            }
            _context.SaveChanges();
        }
        catch
        {
        // Handle errors
        }        
    }
