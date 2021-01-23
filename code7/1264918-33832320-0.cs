    public interface IApplicationUserManager
    {
        IList<string> GetRoles(string userId);
    }
    public class ApplicationUserManager : UserManager<ApplicationUser>, IApplicationUserManager
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }
        public IList<string> GetRoles(string userId)
        {
            return UserManagerExtensions.GetRoles(manager: this, userId: userId);
        }
    }
