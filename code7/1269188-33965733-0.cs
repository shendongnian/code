    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        public class User
        {
            public string userName { get; set; }
            public string password { get; set; }
            public int savingsAcct { get; set; }
            public int checkAcct { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                // here you'll take the user and password from the form
                string userNameEnteredIntoScreen = "???";
                string passwordEnteredIntoScreen = "???";
    
                // build list of valid users (amend to suit)
                var users = new List<User>();
                users.Add(new User
                {
                    userName = "user1",
                    password = "abc",
                    savingsAcct = 1,
                    checkAcct = 2,
                });
                users.Add(new User
                {
                    userName = "user2",
                    password = "xyz",
                    savingsAcct = 3,
                    checkAcct = 4,
                });
    
                // then to check if they're valid
                var user = users.SingleOrDefault(u =>
                    u.userName == userNameEnteredIntoScreen &&
                    u.password == passwordEnteredIntoScreen
                    );
    
                if (user != null)
                {
                    // the user and password was valid, and 'user' variable
                    // now contains the details of the user
                }
            }
        }
    }
