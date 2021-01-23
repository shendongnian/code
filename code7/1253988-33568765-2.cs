    private class ApplicationIdentityFactory : ClaimsIdentityFactory<steam_User, int>
    {
        public async override Task<ClaimsIdentity> CreateAsync(UserManager<steam_User, int> manager, steam_User user, string authenticationType)
        {
            var claims = new[]
                         {
                             new Claim(UserIdClaimType, user.Id.ToString()),
                             new Claim(UserNameClaimType, user.UserName)
                         };
            var identity = new ClaimsIdentity(claims, authenticationType, UserNameClaimType, RoleClaimType);
            if (manager.SupportsUserRole)
            {
                var roles = await manager.GetRolesAsync(user.Id);
                identity.AddClaims(roles.Select(r => new Claim(RoleClaimType, r)));
            }
            if (manager.SupportsUserClaim)
            {
                identity.AddClaims(await manager.GetClaimsAsync(user.Id));
            }
            return identity;
        }
    } 
