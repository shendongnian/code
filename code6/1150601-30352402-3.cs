    public class AdminUser : User
    {
        public AdminUser(string username, bool isActiveDirectoryUser = false)
            : base(username, null, isActiveDirectoryUser)
        { }
        private AdminUser()
        { }
        public override string Area
        {
            get { return UserAreas.Admin; }
        }
    }
