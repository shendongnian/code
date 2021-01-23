    class UserRepository : IUserRepository
            {
                ChatAppDBContext _db = new ChatAppDBContext();
                public UserModel GetByUsernameAndPassword(LogIn login)
                {
                    return _db.Users.Where(u => u.Email == login.Email & u.Password == login.UserPassword).FirstOrDefault();
                }
            }
