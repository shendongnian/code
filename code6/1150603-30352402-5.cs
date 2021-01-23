    public abstract class User : IdentityUser
    {
        public abstract string Area { get; }
        public bool IsActiveDirectoryUser { get; private set; }
        protected User(string username, bool isActiveDirectoryUser = false)
            : base(username)
        {
            IsActiveDirectoryUser = isActiveDirectoryUser;
        }
        protected User()
        { }
    }
