    public class TAccount
    {
        public Account account { get; set; }
        public double transactionAmount { get; set; }
    }
    public class Account
    {
        public int Id { get; set; }
        public string AccountName { get; set; }
        public double Balance { get; set; }
        public string LastOperation { get; set; }
    
    }
