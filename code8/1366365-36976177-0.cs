    public class Response
        {
            public string RequestId { get; set; }
            public string UserId { get; set; }
            public List<ResponseReport> Report { get; set; }
            public string SenderId { get; set; }
        }
    
        public class ResponseReport
        {
            public string Desc { get; set; }
            public int Status { get; set; }
            public string Number { get; set; }
            public DateTime Date { get; set; }
    
        }
