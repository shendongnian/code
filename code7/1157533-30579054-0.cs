    public partial class Bank
    {
      public Bank()
      {
        BankAccounts = new List<BankAccount>();
      }
      public int Code { get; set;}
      public string Name { get; set;}
      public virtual ICollection<BankAccount> BankAccounts { get; set;}
    }
    public partial class BankAccount
    {
      public int BankId { get; set;}
      public int Agency { get; set;}
      public int Account { get; set;}
      public virtual Bank Bank { get; set;}
    }
