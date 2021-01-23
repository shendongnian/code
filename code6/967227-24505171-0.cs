    interface IAccount 
    { 
        string fullName{get;set;} 
        void Balance();
    }
    
    public class User : IAccount 
    { 
      public string fullName { get; set; } 
      public int balance = 10000; 
      public User(string firstName, string lastName) 
      { 
        fullName = firstName + lastName; 
      } 
      public void Balance() 
      { 
        Console.WriteLine("Account balance-" + this.balance); 
      } 
      public void MyBalance() 
      { 
        Console.WriteLine(" My balance"); 
        Balance(); 
      }
    }
