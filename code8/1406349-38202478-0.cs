    public IQueryable<User> Users()
     {
  
         var users = from user in _db.Context.Users
             where user.IsPublic
             select user;
         foreach (var user in users)
            {
                user.PasswordHash = null;
                user.PhoneNumber = null;
                user.Logins.Clear();
                user.Email = null;
                user.AccessFailedCount = 0;
                user.Roles.Clear();
                user.SecurityStamp = null;
                user.TwoFactorEnabled = user.EmailConfirmed = user.PhoneNumberConfirmed = false;
                user.Claims.Clear();
            }
            return users;
        }
