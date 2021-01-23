    public class Account
    { 
       public int Id {get; set;}
       public Customer Customer {get; set;}
       public int CustomerId {get; set;}
       public string AccountNumber {get; set;}
       public double AccountBalance {get; set;}
        
       [ForgienKey("SupercededAccount")]
       public int? SupercededAccountId {get; set;}
        
       public virtual Account SupercededAccount {get;set;}
    }
