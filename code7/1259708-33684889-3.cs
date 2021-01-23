      public class ApplicationUserManager : UserManager<ApplicationUser>
        {
            public ApplicationUserManager(IUserStore<ApplicationUser> store, IIdentityMessageService emailService)
                : base(store)
            {
              this.EmailService = emailService;
            }
        }
