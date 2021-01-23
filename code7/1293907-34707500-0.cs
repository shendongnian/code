    public class MyModel
    {
        public int Code { get; set; }
        public Detected Detected { get; set; }
        public string Lang { get; set; }
        public string[] Text { get; set; }
    }
    
    public class Detected
    {
        public string Lang { get; set; }
    }
