    public class COMPETITION
    {
        public string name { get; set; }
        public string id { get; set; }
        public string ltable { get; set; }
    }
    
    public class RootObject
    {
        public List<COMPETITION> COMPETITIONS { get; set; }
    }
