     public class Payload
        {
        }
    
        public class CustomResponse
        {
            public IList<bool> Success { get; set; }
            public IList<string> ErrorLog { get; set; }
            public IList<string> Referer { get; set; }
            public Payload Payload { get; set; }
        }
