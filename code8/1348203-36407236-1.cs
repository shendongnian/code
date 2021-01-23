    public class TransactionDetails
    {
        public int id { get; set; }
        public string name { get; set; }
        public object description { get; set; }
        public int warning { get; set; }
        public int poor { get; set; }
        public int timeOut { get; set; }
        public int tolerated { get; set; }
        public int frustrated { get; set; }
        public int state { get; set; }
        public bool includeInThroughputCalculation { get; set; }
    }
    
    public class Transaction
    {
        public int order { get; set; }
        public string displayName { get; set; }
        public TransactionDetails transaction { get; set; }
    }
    
    public class RootObject
    {
        public int id { get; set; }
        public List<Transaction> transactions { get; set; }
        public object defies { get; set; }
        public int state { get; set; }
        public string reportDisplayName { get; set; }
    }
