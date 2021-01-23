    public class Response
    {
        public Dictionary<string, SlipItem> salarySlipItems { get; set; }
        public string decimalDigits { get; set; }
        public string status { get; set; }
    }
    public class SlipItem 
    {
        public string value { get; set; }
        public string description { get; set; }
        public string sort { get; set; }
    }
