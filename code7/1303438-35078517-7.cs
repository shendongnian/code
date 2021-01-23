    public class MyLegacyUserManager : UserManager<MyLegacyUser>
    {
        public WorldUserManager(IUserStore<MasterUser> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<MasterUser> passwordHasher, IEnumerable<IUserValidator<MasterUser>> userValidators, IEnumerable<IPasswordValidator<MasterUser>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<MasterUser>> logger, IHttpContextAccessor contextAccessor) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger, contextAccessor)
        {
        }
        public override async Task<bool> CheckPasswordAsync(MasterUser user, string password)
        {
            // This is my own authentication manager class that handles user authentication
           // Add your own code to authenticate your user here
            return new AuthenticationManager().Authenticate(user.EmailAddress, password);
        }
    }    
