    public class TwitterData_Entities
    {
        public List<TwitterData_HashTag> hashtags { get; set; }
        public List<TwitterData_UserMentions> user_mentions { get; set; }
    }
    public class TwitterData_HashTag
    {
        public string text { get; set; }
        public List<int> indices { get; set; }
    }
    public class TwitterData_UserMentions
    {
        public string screen_name { get; set; }
        public string name { get; set; }
        public long id { get; set; }
        public List<int> indices { get; set; }
    }
    
    public class TwitterData
    {
        public TwitterData_Entities entities { get; set; }
    }
