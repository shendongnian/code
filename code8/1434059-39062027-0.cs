    public class jsonResults<T> {
        public int success { get; set; }
        public string message { get; set; }
        public List<T> resultArray { get; set; }
    }
