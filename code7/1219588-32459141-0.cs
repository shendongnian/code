    public class Pinner
    {
        public string about { get; set; }
        public string location { get; set; }
        public string full_name { get; set; }
        public int follower_count { get; set; }
        public string image_small_url { get; set; }
        public int pin_count { get; set; }
        public string id { get; set; }
        public string profile_url { get; set; }
    }
    
    
    public class Pin
    {
        public object attribution { get; set; }
        public string description { get; set; }
        public Pinner pinner { get; set; }
        public int repin_count { get; set; }
        public string dominant_color { get; set; }
        public int like_count { get; set; }
        public string link { get; set; }
        public Images images { get; set; }
        public Embed embed { get; set; }
        public bool is_video { get; set; }
        public string id { get; set; }
    }
    
    public class User
    {
        public string about { get; set; }
        public string location { get; set; }
        public string full_name { get; set; }
        public int follower_count { get; set; }
        public string image_small_url { get; set; }
        public int pin_count { get; set; }
        public string id { get; set; }
        public string profile_url { get; set; }
    }
    
    public class Data
    {
        public List<Pin> pins { get; set; }
        public User user { get; set; }
        public Board board { get; set; }
    }
    
    public class RootObject
    {
        public string status { get; set; }
        public int code { get; set; }
        public string host { get; set; }
        public string generated_at { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
    }
