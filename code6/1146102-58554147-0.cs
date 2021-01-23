    public class ApplicationUser : IdentityUser
    {
        ...//some additional properties goes here
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            
            //my custom claims
            List<Claim> claims = new List<Claim>
            {
                new Claim("FirstName", FirstName.ToString()),
                new Claim("MiddleName", MiddleName.ToString()),
                new Claim("LastName", LastName.ToString()),
                new Claim("Position", Position.ToString()) //if Position is NULL, it will throw null reference exception
            };
            userIdentity.AddClaims(claims);
            return userIdentity;
        }
    }
