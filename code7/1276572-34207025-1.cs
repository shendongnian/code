    public class RoleStoreRepository : RoleStore<IdentityRole>
    {
        public RoleStoreRepository(AuthContext context)
            : base(context)
        {
        }
    }
