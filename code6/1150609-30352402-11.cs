    public class AdminUser : User
    {
        public AdminUser(string username, bool isActiveDirectoryUser = false)
            : base(username, isActiveDirectoryUser)
        { }
        private AdminUser()
        { }
        public override string Area
        {
            get { return UserAreas.Admin; }
        }
    }
