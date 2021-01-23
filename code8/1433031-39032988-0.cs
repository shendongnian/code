    public class ClaimsTransformer : IClaimsTransformer
    {
        // i assume you have a user service in which you get user info via entity framework
        private readonly IUserService _userService;   
        public ClaimsTransformer(IUserService userService)
        {
             _userService = userService;
        }
        public async Task<ClaimsPrincipal> TransformAsync(ClaimsTransformationContext context)
        {
            var identity = ((ClaimsIdentity)context.Principal.Identity);
            // ... add user claims if required
            var roles = _userService.GetRoles(identity.Name);
            foreach(var role in roles)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, role));
            }
            return await Task.FromResult(context.Principal);
        }
    }
