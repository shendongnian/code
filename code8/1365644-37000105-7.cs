    public class UserStore:  UserStore<User, Role, int, UserLogin, UserRole, UserClaim>
    {
        public UserStore(MyContext context)
            : base(context)
        {
        }
    }
