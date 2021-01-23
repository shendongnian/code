    namespace Repository
    {
        public MyContextDataContext : DbContext 
        {
            public DbSet<User> Users { get; set; }
        }
        public class UserRepository
        {
            private MyContextDataContext _myContext = new  MyContextDataContext();
    
            public User GetUser()
            {
                return _myContext.Users.FirstOrDefault();
            }
        }
    }
