    public User ChangePassword(int userId, string password)
    {
      var user = new User() { Id = userId };
      _context.Users.Attach(user); 
      user.Password = password;
      _context.SaveChanges();
      
      return user;
    }
