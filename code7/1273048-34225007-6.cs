    public class EmailDTO
    {
        public string From { get; set; }
        public IList<string> To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
