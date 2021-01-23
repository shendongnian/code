    public class ApplicationUserManager
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store, IIdentityMessageService emailService)
    : base(store)
        {
            CalledAfterConstruction();
        }
        protected virtual void CalledAfterConstruction()
        {
            this.EmailService = emailService;
            var dataProtectionProvider = Startup.DataProtectionProvider;
            this.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
        }
    }
