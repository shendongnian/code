    public class MyUserStore : UserStore<MyUser>
    {
        public MyUserStore(Context context)
            : base(context)
        {
        }
    }
