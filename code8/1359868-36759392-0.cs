    public class Data
    {
        public string role_id { get; set; }
        public string role_name { get; set; }
    }
    
    public class RootObject
    {
        public List<Data> data { get; set; }
    }
