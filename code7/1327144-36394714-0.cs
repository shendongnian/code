    public class MyUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {
        public MyUserClaimsPrincipalFactory (
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<IdentityOptions> optionsAccessor) : base(userManager, roleManager, optionsAccessor)
        {
        }
        public async override Task<ClaimsPrincipal> CreateAsync(ApplicationUser user)
        {
            var principal = await base.CreateAsync(user);
            //Putting our Property to Claims
            //I'm using ClaimType.Email, but you may use any other or your own
            ((ClaimsIdentity)principal.Identity).AddClaims(new[] {
            new Claim(ClaimTypes.Email, user.MyProperty)
        });
            return principal;
        }
    }
