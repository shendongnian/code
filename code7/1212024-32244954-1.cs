    public class User : IUser
    {
        private Entities.User _eUser;
        public Entities.User EUser
        {
            get { return _eUser; }
            set { _eUser = value; }
        }
    
        public string Id
        {
            get
            {
                return _eUser.Id.ToString();
            }
        }
    }
