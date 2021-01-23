    public class UserService : IUserService
    {
        //DI the repository from Startup.cs - see previous code block
        private IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task AuthenticateLocalAsync(LocalAuthenticationContext context)
        {
            var user = _userRepository.Find(context.UserName);
            //check if passwords match against user column 
            //My password was hashed, 
            //so I had to hash it with the saved salt first and then compare.
            if (user.Password == context.Password)
            {
                context.AuthenticateResult = new AuthenticateResult(
                    user.UserId.ToString(),
                    user.Email,
    
                    //I set up some claims 
                    new Claim[]
                    {
                        //Firstname and Surname are DB columns mapped to User object (from table [User])
                        new Claim(Constants.ClaimTypes.Name, user.Firstname + " " + user.Surname),
                        new Claim(Constants.ClaimTypes.Email, user.Email),
                        new Claim(Constants.ClaimTypes.Role, user.Role.ToString()),
                        //custom claim
                        new Claim("company", user.Company)
                    }
                );
            }
            return Task.FromResult(0);
        }
        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            //find method in my repository to check my user email
            var user = _userRepository.Find(context.Subject.Identity.Name);
            if (user != null)
            {
                var claims = new Claim[]
                    {
                        new Claim(Constants.ClaimTypes.Name, user.Firstname + " " + user.Surname),
                        new Claim(Constants.ClaimTypes.Email, user.Email),
                        new Claim(Constants.ClaimTypes.Role, user.Role.ToString(), ClaimValueTypes.Integer),
                        new Claim("company", user.Company)
                };
                context.IssuedClaims = claims.Where(x => context.RequestedClaimTypes.Contains(x.Type));
            }
            return Task.FromResult(0);
        }
        public Task IsActiveAsync(IsActiveContext context)
        {
            var user = _userRepository.Find(context.Subject.Identity.Name);
            return Task.FromResult(user != null);
        }
    }
