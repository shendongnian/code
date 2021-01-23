    public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
            {
                // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
                var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
                // Add custom user claims here
                userIdentity.AddClaim(new Claim("FirstName", this.FirstName));
                userIdentity.AddClaim(new Claim("LastName", this.LastName));
                userIdentity.AddClaim(new Claim("FullName", this.FullName));
                userIdentity.AddClaim(new Claim("MobileNo", this.PhoneNumber)); 
                userIdentity.AddClaim(new Claim("Id", this.Id));
                return userIdentity;
            }
