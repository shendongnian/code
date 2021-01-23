    public class ApplicationUserManager : UserManager<SampleUser>
        {
            public ApplicationUserManager(IUserStore<SampleUser> store, IDataProtectionProvider dataProtectionProvider)
                : base(store)
            {
                // Configure validation logic for usernames
                this.UserValidator = new UserValidator<SampleUser>(this)
                {
                    AllowOnlyAlphanumericUserNames = false,
                    RequireUniqueEmail = true
                };
    
                // Configure validation logic for passwords
                this.PasswordValidator = new PasswordValidator
                {
                    RequiredLength = 6,
                    RequireNonLetterOrDigit = false,
                    RequireDigit = false,
                    RequireLowercase = false,
                    RequireUppercase = false,
                };
    
                // Configure user lockout defaults
                this.UserLockoutEnabledByDefault = true;
                this.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
                this.MaxFailedAccessAttemptsBeforeLockout = 5;
    
                // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
                // You can write your own provider and plug it in here.
                this.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<SampleUser>
                {
                    MessageFormat = "Your security code is {0}"
                });
                this.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<SampleUser>
                {
                    Subject = "Security Code",
                    BodyFormat = "Your security code is {0}"
                });
                this.EmailService = new EmailService();
                this.SmsService = new SmsService();
    
               // var dataProtectionProvider = Startup.DataProtectionProvider;
                if (dataProtectionProvider != null)
                {
                    IDataProtector dataProtector = dataProtectionProvider.Create("ASP.NET Identity");
    
                    this.UserTokenProvider = new DataProtectorTokenProvider<SampleUser>(dataProtector);
                }
            }
    
           
        }
