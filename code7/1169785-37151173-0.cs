    public class ApplicationClaimsIdentityFactory : ClaimsIdentityFactory<ApplicationUser>
    {
        // This claim value is taken from Login View
        public static readonly string MyClaimKey = "app:MyClaimKey";
        public string MyClaimValue { get; set; }
        
        public async override Task<ClaimsIdentity> CreateAsync(UserManager<ApplicationUser, string> manager, ApplicationUser user, string authenticationType)
        {
            var identity = await base.CreateAsync(manager, user, authenticationType);
            identity.AddClaim(new Claim(MyClaimKey, MyClaimValue));
            return identity;
        }
    }
