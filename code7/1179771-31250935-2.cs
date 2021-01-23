    public class User
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
    
        public bool IsBirthday
        {
            get
            {
                if (Birthday.Day == DateTime.Now.Day && Birthday.Month == DateTime.Now.Month)
                    return true;
    
                return false;
            }        
        }
    }
    public class SomeClass
    {    
    
        private List<User> Users = new List<User>();
        public void PopulateNames()
        {
            Users.Add(new User()
            {
                Name = "name 1",
                Brithday = DateTime.Parse("11.11.1988")
            };
        
            // etc
        }
    
        public void DoSomethingOnUsersWithABirthday()
        {
            foreach (User user in Users)
            {
                if (user.IsBirthday)
                {
                    // do something for their birthday.
                    Console.WriteLine(string.format("It's {0}'s birthday!", user.Name));
                }
            }
        }
    }
