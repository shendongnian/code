    public class Rootobject
    {
        public string CountryList { get; set; }
        public Error Error { get; set; }
    }
    
    public class Error
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
