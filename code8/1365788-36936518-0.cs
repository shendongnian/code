    public class Account
    {
        public int Id { get; set; } // or account number
    
        // your rest of the properties
        public decimal AmountBalance { get; set; }
           
    }
    
    
    public class Expense
    {
        public int Id { get; set; }
        public int AccountId { get; set; } // Foreign key
        public string Details { get; set; }
        public decimal Amount { get; set; }
    }
    
    public class Profit
    {
        public int Id { get; set; }
        public int AccountId { get; set; } // Foreign key
        public string Details { get; set; }
        public decimal Amount { get; set; }
    }
