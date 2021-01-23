    public class FakeSignInManager : SignInManager<ApplicationUser>
    {
        public FakeSignInManager(IHttpContextAccessor contextAccessor)
            : base(new FakeUserManager(),
                  contextAccessor,
                  new Mock<IUserClaimsPrincipalFactory<ApplicationUser>>().Object,
                  new Mock<IOptions<IdentityOptions>>().Object,
                  new Mock<ILogger<SignInManager<ApplicationUser>>>().Object)
        {
        }
        public override Task SignInAsync(ApplicationUser user, bool isPersistent, string authenticationMethod = null)
        {
            return Task.FromResult(0);
        }
        public override Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure)
        {
            return Task.FromResult(SignInResult.Success);
        }
        public override Task SignOutAsync()
        {
            return Task.FromResult(0);
        }
    }
