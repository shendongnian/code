    public class UserService : IUserService 
    {
        public static Func<MyDbContext> CreateContext = () => new MyDbContext();
    
        public UserService ()
        {
        } 
        public void AddUser(UserModel userModel)
        {
            ...
            using (var context = CreateContext())
            {
                context.Users.Add(user);
            }
        }
    }
