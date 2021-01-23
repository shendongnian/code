    public class UserStoreRepository : UserStore<IdentityUser>
    {
        public UserStoreRepository(AuthContext context)
            : base(context)
        {
        }
    }
