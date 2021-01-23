    public class User
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string created_at { get; set; }
        public List<string> tags { get; set; }
    }
            
    public class RootObject
    {
        public int page { get; set; }
        public int page_size { get; set; }
        public int total_count { get; set; }
        public int count { get; set; }
        public Dictionary<string, User>  data { get; set; }
    }
