    public class ApplicationUser : IdentityUser
    {
        // start custom properties
        public string HomeTown { get; set; }
        public System.DateTime? BirthDate { get; set; }
        // end custom properties
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
