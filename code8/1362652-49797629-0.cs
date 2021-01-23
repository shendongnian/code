    using Microsoft.AspNetCore.Http;
    using MyProject.Interfaces;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace MyProject.Web.Services
    {
        public class UserResolverService : IUserResolverService
        {
            private readonly IHttpContextAccessor _context;
            public UserResolverService(IEnumerable<IHttpContextAccessor> context)
            {
                _context = context.FirstOrDefault();
            }
    
            public string GetCurrentUser()
            {
                return _context?.HttpContext?.User?.Identity?.Name ?? "unknown_user";
            }
        }
    }
    
    ...
    private readonly IUserResolverService userResolverService;
    public MyContext(DbContextOptions<MyContext> options, IUserResolverService userResolverService) : base(options)
    {
        this.userResolverService = userResolverService;
    }
