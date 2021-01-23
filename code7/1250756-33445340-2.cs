    public class ApplicationUserManager: UserManager<User, int>
    {
        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
             var manager = new ApplicationUserManager(new MyUserStore(context.Get<MyDbContext>()));
             // rest of code
        }
    }
