    public class IdentityUserManager : UserManager<IdentityUser>
    {
        public IdentityUserManager(IUserStore<IdentityUser> store)
            : base(store)
        {
            PasswordHasher = new BackCompatPasswordHasher();
        }
    }
