    public class MyOwnUserStore : UserStore<ApplicationUser> {
        public MyOwnUserStore(ApplicationDbContext context, IdentityErrorDescriber describer = null)
            : base(context, describer) {
        }
        ...
    }
