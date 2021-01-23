    public class Bank
    {
        public string id { get; set; }
        public string short_name { get; set; }
        public string full_name { get; set; }
        public string logo { get; set; }
        public string website { get; set; }
    }
    
    public class RootObject
    {
        public List<Bank> banks { get; set; }
    }
