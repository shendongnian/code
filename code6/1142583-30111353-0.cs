    public class Item
    {
        public int id { get; set; }
        public int date { get; set; }
        public int @out { get; set; }
        public int user_id { get; set; }
        public int read_state { get; set; }
        public string title { get; set; }
        public string body { get; set; }
    }
    
    public class Response
    {
        public int count { get; set; }
        public List<Item> items { get; set; }
    }
    
    public class RootObject
    {
        public Response response { get; set; }
    }
