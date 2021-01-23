    public abstract class User : IdentityUser
    {
        public int? OwnerId { get; private set; }
        public abstract string Area { get; }
        public bool IsActiveDirectoryUser { get; private set; }
        protected User(string username, int? ownerId, bool isActiveDirectoryUser = false)
            : base(username)
        {
            OwnerId = ownerId;
            IsActiveDirectoryUser = isActiveDirectoryUser;
        }
        protected User()
        { }
    }
