    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private MyUserManager _myUserService { get; set; }
        public ResourceOwnerPasswordValidator()
        {
            _myUserService = new MyUserManager();
        }
        public async Task<CustomGrantValidationResult> ValidateAsync(string userName, string password, ValidatedTokenRequest request)
        {
            var user = await _myUserService.FindByNameAsync(userName);
            if (user != null && await _myUserService.CheckPasswordAsync(user, password))
            {
                return new CustomGrantValidationResult(user.EmailAddress, "password");
            }
            return new CustomGrantValidationResult("Invalid username or password");
        }
    }
    public class ProfileService : IProfileService
    {
        MyUserManager _myUserManager;
        public ProfileService()
        {
            _myUserManager = new MyUserManager();
        }
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var sub = context.Subject.FindFirst("sub")?.Value;
            if (sub != null)
            {
                var user = await _myUserManager.FindByIdAsync(sub);
                var cp = await getClaims(user);
                var claims = cp.Claims;
                if (context.AllClaimsRequested == false ||
                    (context.RequestedClaimTypes != null && context.RequestedClaimTypes.Any()))
                {
                    claims = claims.Where(x => context.RequestedClaimTypes.Contains(x.Type)).ToArray().AsEnumerable();
                }
                context.IssuedClaims = claims;
            }
        }
        public Task IsActiveAsync(IsActiveContext context)
        {
            return Task.FromResult(0);
        }
        private async Task<ClaimsPrincipal> getClaims(CustomerSite user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            var userId = await _myUserManager.GetUserIdAsync(user);
            var userName = await _myUserManager.GetUserNameAsync(user);
            var id = new ClaimsIdentity();
            id.AddClaim(new Claim(JwtClaimTypes.Id, userId));
            id.AddClaim(new Claim(JwtClaimTypes.PreferredUserName, userName));
                        
            var roles = await _myUserManager.GetRolesAsync(user);
            foreach (var roleName in roles)
            {
                id.AddClaim(new Claim(JwtClaimTypes.Role, roleName));                
            }
                        
            id.AddClaims(await _myUserManager.GetClaimsAsync(user));
            
            return new ClaimsPrincipal(id);
        }
    }
