    public class UserService : IUserService 
    {
        private MyDbContext _context;
    
        public UserService (MyDbContext dbContext)
        {
            _context = dbContext;
        } 
    }
