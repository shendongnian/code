    public class ERPContext : DbContext
    {
        private readonly HttpContext _httpContext;
    
        public ERPContext(DbContextOptions<ERPContext> options, IHttpContextAccessor httpContextAccessor = null)
            : base(options)
        {
            _httpContext = httpContextAccessor?.HttpContext;
        }
    
        //..
    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var clientClaim = _httpContext?.User.Claims.Where(c => c.Type == ClaimTypes.GroupSid).Select(c => c.Value).SingleOrDefault();
                if (clientClaim == null) clientClaim = "DEBUG"; // Let's say there is no http context, like when you update-database from PMC
                optionsBuilder.UseSqlServer(RetrieveYourBeautifulClientConnection(clientClaim));
            }
        }
    
        //..
    }
