    public class Account
    { 
       [Key]
       public int Id {get; set;}
       
       [ForgienKey("Customer")]
       public int CustomerId {get;set;}
       //navigator to customer
       public virtual Customer Customer {get; set;}
       public string AccountNumber {get; set;}
       public double AccountBalance {get; set;}
           
       [ForgienKey("SupercededAccount")]
       public int? SupercededAccountId {get; set;}
        
       public virtual Account SupercededAccount {get;set;}
    }
    public class Customer
    {
       [Key]
       public int Id {get; set;}
       public string FirstName {get; set;}
       public string LastName {get; set;}
       
       public virtual ICollection<Account> Accounts {get; set;}
    }
