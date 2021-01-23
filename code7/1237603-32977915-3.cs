    public class Adjunct
    {
        public int id { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public string categoryDisplay { get; set; }
        public string createDate { get; set; }
    }
    
    public class AdjunctsReply
    {
        public int currentPage { get; set; }
        public int numberOfPages { get; set; }
        public int totalResults { get; set; }
        public List<Adjunct> adjuncts { get; set; }
        public string status { get; set; }
    }
