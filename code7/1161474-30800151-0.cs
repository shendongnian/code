    public class WebsiteUserManager : UserManager<ApplicationUser>
    {
        public WebsiteUserManager(IUserStore<ApplicationUser> manager)
            : base(manager)
        {
        }
    }
