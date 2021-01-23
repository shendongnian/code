        public class ClaimsFactory : ClaimsIdentityFactory<User>
    {
        public async override Task<ClaimsIdentity> CreateAsync(UserManager<User> manager, User user, string authenticationType)
        {
            var identity = await base.CreateAsync(manager, user, authenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Area, user.Area, ClaimValueTypes.String));
            return identity;
        }
    }
