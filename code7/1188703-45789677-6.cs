    // Configure the application user manager used in this application. 
    //UserManager is defined in ASP.NET Identity and is used by the application.
    public class ApplicationUserManager : UserManager<User>
    {
        public ApplicationUserManager(IUserStore<User> store, IIdentityMessageService emailService)
            : base(store)
        {
            this.EmailService = emailService;
        }
    
        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var manager = new ApplicationUserManager(new UserStore<User>(context.Get<ApplicationDbContext>()), new SmtpEmailService());
            .
            .
            .
            .
            return manager;
        }
    }
