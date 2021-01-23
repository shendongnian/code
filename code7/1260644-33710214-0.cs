    class User
    {
        private static List<User> users;
        private string _name;
        public User(string name)
        {
            _name = name;
        }
        public string GetName()
        {
            return _name;
        }
        public void SetName(string name)
        {
            _name = name;
        }
        public static void AddUser(User u)
        {
            if (users == null)
                users = new List<User>();
            users.Add(u);
        }
        public static void GetUsers()
        {
            foreach (User u in users)
            {
                //Display users
            }
        }
    }
