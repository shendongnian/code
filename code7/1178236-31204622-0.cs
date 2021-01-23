    public class Message
    {
        public string Message { get; set; }
    }
    
    public class EmpDetails//changed name
    {
        public string Email { get; set; }
        public string EmpCode { get; set; }
        public string MobileNo { get; set; }
        public string Name { get; set; }
        public string Pan { get; set; }
        public string Photo { get; set; }//changed type
        public Message message { get; set; }
    }
