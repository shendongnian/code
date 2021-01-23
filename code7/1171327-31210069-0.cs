     public static CustomUserManager CreateUserManager(IdentityFactoryOptions<CustomUserManager> options, IOwinContext context)
            {
                var manager = new CustomUserManager(new CustomUserStore(context.Get<CustomIdentityDbContext>()));
    
                manager.UserValidator = new UserValidator<CustomUser, int>(manager)
                {
                    AllowOnlyAlphanumericUserNames = false,
                    RequireUniqueEmail = true
                };
    
                manager.UserLockoutEnabledByDefault = true;
                manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(10);
                manager.MaxFailedAccessAttemptsBeforeLockout = 5;
    
                manager.PasswordValidator = new PasswordValidator
                {
                    RequiredLength = 6,
                    RequireNonLetterOrDigit = true,
                    RequireDigit = true,
                    RequireLowercase = true,
                    RequireUppercase = true,
                };
    
                manager.EmailService = new IdentityEmailService();
    
                var dataProtectionProvider = options.DataProtectionProvider;
                if (dataProtectionProvider != null)
                {
                    manager.UserTokenProvider = new DataProtectorTokenProvider<CustomUser, int>(dataProtectionProvider.Create("My_Application"))
                    {
                        TokenLifespan = TimeSpan.FromHours(2)
                    };
                }
    
                return manager;
            }
