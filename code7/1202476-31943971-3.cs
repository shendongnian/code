    public class UserService
    {
        IMyContextFactory contextFactory
    
        public UserService(IMyContextFactory contextFactory)
        {
            contextFactory = contextFactory;
        }
    
        public List<User> GetUsers() 
        {
             using(var context = this.contextFactory.Create())
             {
                  return context.Users.ToList();
             }
        }
    }
