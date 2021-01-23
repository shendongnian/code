    class UserRepository : IUserRepository
    {
           ChatAppDBContext _db = new ChatAppDBContext();
           public UserModel GetByUsernameAndPassword(LogIn login)
           {
               return _db.Users
                 .Where(u => u.Email == login.Email & u.Password == login.UserPassword)
                 .FirstOrDefault()
                 .Select(x => new UserModel
                 {
                      Name = x.Name
                 });
           }
    }
    
    public class UserModel
    {
       public string Name { get; set; }
    }
