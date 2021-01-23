     public static UserManager<User> Create(IdentityFactoryOptions<UserManager<User>> options, IOwinContext context)
        {
            var userManager = new UserManager<User>(new UserStore());
            // this is the key 
            userManager.UserValidator = new UserValidator<User>(userManager) { AllowOnlyAlphanumericUserNames = false };
            // other settings here
            userManager.UserLockoutEnabledByDefault = true;
            userManager.MaxFailedAccessAttemptsBeforeLockout = 5;
            userManager.DefaultAccountLockoutTimeSpan = TimeSpan.FromDays(1);
            
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                userManager.UserTokenProvider = new DataProtectorTokenProvider<User>(dataProtectionProvider.Create("ASP.NET Identity"))
                {
                    TokenLifespan = TimeSpan.FromDays(5)
                };
            }
            return userManager;
        }
