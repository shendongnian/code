    public class Filters
    {
        public int game { get; set; }
        public int mediatype { get; set; }
        public int location { get; set; }
        public int contributor { get; set; }
    }
    public class RootObject
    {
        public Filters filters { get; set; }
        public List<int> tags { get; set; }
        public string search { get; set; }
        public int startindex { get; set; }
        public int fetchcount { get; set; }
    }
