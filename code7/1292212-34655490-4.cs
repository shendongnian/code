    public enum TransactionType 
      {
        C,
        D
      }
  
    public class Transaction
    {
        public int Id {get; set;}
        public DateTime Date{get;set;}
        public double Value{get;set;}
        public TransactionType Type{get;set;}
        public int Account{get;set;}
    }
