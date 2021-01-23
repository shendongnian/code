      public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User, string> manager, IAuthenticationManager authentication = null)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            if (authentication != null)
            {
                ExternalLoginInfo info = authentication.GetExternalLoginInfo();
                if (info != null)
                    foreach (Claim claim in info.ExternalIdentity.Claims.Where(claim => !userIdentity.HasClaim(c => c.Type == claim.Type)))
                    {
                        userIdentity.AddClaim(claim);
                        await manager.AddClaimAsync(userIdentity.GetUserId(), claim);
                    }
            }
            return userIdentity;
        }
