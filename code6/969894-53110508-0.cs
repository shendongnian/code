        public class UserClaimService : UserClaimsPrincipalFactory<ApplicationUser, ApplicationRole>
        {
            private readonly ApplicationDbContext _dbContext;
            public UserClaimService(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IOptions<IdentityOptions> optionsAccessor) : base(userManager, roleManager, optionsAccessor)
            {
                _dbContext = dbContext;
            }
            public override async Task<ClaimsPrincipal> CreateAsync(ApplicationUser user)
            {
                var principal = await base.CreateAsync(user);
                // Get user claims from DB using dbContext
                // Add claims
                ((ClaimsIdentity)principal.Identity).AddClaim(new Claim("claimType", "some important claim value"));
                return principal;
            }
        }
