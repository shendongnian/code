    public class ApplicationUserManager : UserManager<ASPNETIdentity2.Models.MyUser, string>
    {
        public ApplicationUserManager(IUserStore<ASPNETIdentity2.Models.MyUser, string> store)
            : base(store)
        {
        }
        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var manager = new ApplicationUserManager(new MyUserStore(context.Get<MyContext>()));
            manager.UserValidator = new UserValidator<MyUser, string>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            manager.PasswordValidator = new PasswordValidator()
            {
                RequiredLength = 5,
                RequireNonLetterOrDigit = false,     // true
                // RequireDigit = true,
                RequireLowercase = false,
                RequireUppercase = false,
            };
            return (manager);
        }
    }
