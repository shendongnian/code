    public class smsstatus
    {
        public string date { get; set; }
        public int status { get; set; }
        public string desc { get; set; }
    }
    public class Request
    {
        public string requestId { get; set; }
        public Dictionary<string, smsstatus> numbers { get; set; } //<-- See this line
    }
