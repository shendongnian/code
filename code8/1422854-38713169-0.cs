    class User
    {
        // make those fields public for accessibility
        public string Username;
        public string Password;
        public string NAME;
        public string Age;
        public User(string Username, string Password, string NAME, string Age)
        {
            // assign each fields with arguments from constructor
            this.Username = Username;
            this.Password = Password;
            this.NAME = NAME;
            this.Age = Age;
        }
    }
