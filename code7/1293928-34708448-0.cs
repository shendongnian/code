    public class Payer
    {
        public string payment_method { get; set; }
    }
    
    public class Amount
    {
        public string total { get; set; }
        public string currency { get; set; }
    }
    
    public class Transaction
    {
        public Amount amount { get; set; }
        public string description { get; set; }
        public List<object> related_resources { get; set; }
    }
    
    public class Link
    {
        public string href { get; set; }
        public string rel { get; set; }
        public string method { get; set; }
    }
    
    public class RootObject
    {
        public string id { get; set; }
        public string intent { get; set; }
        public string state { get; set; }
        public Payer payer { get; set; }
        public List<Transaction> transactions { get; set; }
        public string create_time { get; set; }
        public List<Link> links { get; set; }
    }
