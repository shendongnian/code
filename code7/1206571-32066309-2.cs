    public class MyUserStore : UserStore<MyUser>
    {
        public UserStore(Context context)
            : base(context)
        {
        }
    }
