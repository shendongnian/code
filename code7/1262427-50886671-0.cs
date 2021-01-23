    public class ApplicationUserManager : UserManager<SmartUser, Guid>
    {
        //This manager seems to get re-created on every call! So rather keep a singleton...
        private static ApplicationUserManager _userManager;
        private ApplicationUserManager(IUserStore<SmartUser, Guid> store)
            : base(store)
        {
        }
        internal static void Destroy(IdentityFactoryOptions<ApplicationUserManager> options, ApplicationUserManager manager)
        {
            //We don't ever want to destroy our singleton - so just ignore
        }
        internal static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            if (_userManager == null)
            {
                lock (typeof(ApplicationUserManager))
                {
                    if (_userManager == null)
                        _userManager = CreateManager(options, context);
                }
            }
            return _userManager;
        }
        private static ApplicationUserManager CreateManager(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        { 
           ... your existing Create code ...
        }
    }
