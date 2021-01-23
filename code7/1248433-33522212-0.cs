    public class ApplicationUser : IdentityUser, IPayCaddyEntity
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    
        public string FullName { get; set; }
        public string CellNumber { get; set; }
        //from the IPayCaddyEntity
        public string Id { get; set; }
    }
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Configurations.Add(new ApplicationUserConfig());                
        base.OnModelCreating(modelBuilder);
    }
