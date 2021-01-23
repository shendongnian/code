    public class LessItemList
    {
        public string a { get; set; }
        public string b { get; set; }
    }
    
    public class BillTransList
    {
        public string aa { get; set; }
        public string ss { get; set; }
        public List<LessItemList> LessItemList { get; set; }
    }
    
    public class RootObject
    {
        public List<BillTransList> BillTransList { get; set; }
        public string aq { get; set; }
    }
