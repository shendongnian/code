    public class Pull
    {
        public string character { get; set; }
    }
    public class RootObject
    {
        public string username { get; set; }
        public int currency { get; set; }
        public List<Pull> pulls { get; set; }
    }
