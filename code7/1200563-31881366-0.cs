    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, 
                            DefaultAuthenticationTypes.ApplicationCookie);
    
            // Add custom claim
            userIdentity.AddClaim(new Claim("FavouriteDrink", "Beer"));
            var claims = userIdentity.Claims;
    
            foreach(var claim in claims)
            {
                Debug.Print(string.Format($"{claim.Value}, {claim.ValueType}, {claim.Issuer}, {claim.OriginalIssuer}, {claim.Type}"));
    
                foreach(var property in claim.Properties)
                {
                    Debug.Print(string.Format($"{property.Key}, {property.Value}"));
                }
            }
    
            return userIdentity;
        }
    }
