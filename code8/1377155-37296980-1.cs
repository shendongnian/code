    public class MyService 
    {
        public readonly Func<MyDbContext> createMyContext;
        public MyService(Func<MyDbContext> contextFactory)
        {
            this.createContext = contextFactory;
        }
        public User GetUserById(Guid userId) 
        {
            // note we're calling the delegate here which 
            // creates a new instance every time
            using(var context = createContext()) 
            {
                return context.User.FirstOrDefault(u => u.Id = userId);
            }
        }
    }
