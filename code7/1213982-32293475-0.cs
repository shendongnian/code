    public class BizcardData
    {
        public string company { get; set; }
        public string designation { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
    }
    public class TransData
    {
        public string date { get; set; }
        public string location { get; set; }
        public string tag { get; set; }
        public string time { get; set; }
    }
    public class Transactions
    {
        public BizcardData bizcardData { get; set; }
        public TransData transData { get; set; }
    }
