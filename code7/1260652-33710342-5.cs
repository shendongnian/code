    class UserList
    {
        private List<User> _users;
        public UserList()
        {
            _users = new List<User>();
        }
        public void Add(User user)
        {
            Users.Add(user);
        }
        public void GetUsers()
        {
            foreach (var user in Users)
            {
                Console.WriteLine(user.ToString());
            }
        }
        public List<User> Users
        {
            get { return _users; }
        }
    }
