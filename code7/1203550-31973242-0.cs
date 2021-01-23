    public class Account
    {
        public decimal Amount { get; set; }
        
        public Account(decimal amount)
        {
            Amount = amount;
        }
        public decimal CalculateTax(decimal percentage)
        {
            return percentage * Amount;
        }
    }
