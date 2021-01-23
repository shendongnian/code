    public class ApplicationUser : IdentityUser
    {
        // some code here
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            userIdentity.AddClaim(new Claim("ProfilePicture", this.ProfilePicture));
            return userIdentity;
        }
    }
