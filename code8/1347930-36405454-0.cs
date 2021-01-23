    public class UserResolverService  
    {
        private readonly IHttpContextAccessor _context;
        public UserResolverService(IHttpContextAccessor context)
        {
            _context = context;
        }
    
        public string GetUser()
        {
           return await _context.HttpContext.User?.Identity?.Name;
        }
    }
