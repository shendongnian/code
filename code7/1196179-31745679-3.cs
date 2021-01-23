    class UserRepository : IUserRepository
    {
        ChatAppDBContext _db = new ChatAppDBContext();
        public Login GetByUsernameAndPassword(LogIn login)
        {
             var userResult = _db.Users.Where(u => u.Email == login.Email & u.Password == login.UserPassword).FirstOrDefault();
             if (userResult == null)
                 // throw new Exception() or return new Login();
             Login loginResult = new Login();
             loginResult.Email = userResult.Email;
             return loginResult;                    
        }
    }
