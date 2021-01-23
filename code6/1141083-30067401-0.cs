    public class TechUser
    {
        public string UserName {get; private set;}
        public string Password{get; private set;}
        public TechUser(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
