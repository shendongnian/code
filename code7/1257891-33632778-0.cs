    public class User
    {
        public string userId { get; set; }
    }
    
    public class RootObject
    {
        public User user { get; set; }
        public string authenticationToken { get; set; }
    }
