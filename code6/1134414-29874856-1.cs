    public class Data
    {
        public int ID { get; set; }
        public float value { get; set; }
    }//Data
    public class Account
    {
        public string type { get; set; }
        public List<Data> Data { get; set; }
        public string Datetime { get; set; }
        public string customerID { get; set; }
    }//Account
