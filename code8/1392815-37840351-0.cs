    public class ApplicationUser : IdentityUser<int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        [ForeignKey("Location")]
        public int CurrentLocationId { get; set; }
        public virtual Company Company { get; set; }
    
        public virtual Location Location { get; set; }
    
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
    
            userIdentity.AddClaim(new Claim("CompanyId", this.CompanyId.ToString() ));
            userIdentity.AddClaim(new Claim("CurrentLocationId", this.CurrentLocationId.ToString()));
            return userIdentity;
        }
    }
    public class ApplicationUserLogin : IdentityUserLogin<int>
    {
    }
    public class ApplicationUserRole : IdentityUserRole<int>
    {
        [ForeignKey("RoleId")]
        public virtual ApplicationRole Role { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
    }
    public class ApplicationRole : IdentityRole<int, UserRole>
    {
        
    }
    public class ApplicationUserClaim : IdentityUserClaim<int>
    {
    }
