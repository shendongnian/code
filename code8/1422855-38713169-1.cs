    class User
    {
        // Dont forget to add // using System.Collections.Generic;
        // on top of the file otherwise List<> would not be available
        public static List<User> UserList = new List<User>();
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
