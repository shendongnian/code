    public class User
    {
        public string id { get; set; }
        public string username { get; set; }
        public string full_name { get; set; }
        public string profile_picture { get; set; }
    }
    
    public class RootObject
    {
        public string access_token { get; set; }
        public User user { get; set; }
    }
