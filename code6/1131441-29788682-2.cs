    class Account
    {
        string AccountName { get; set; }
        string Name { get; set; }
    }
    public class TestClass 
    {
        List<Account> Accounts = new List<Account>();   
    }
    public Account GetTestClass(Account account)
    {
         return Accounts.Where(account => a.AccountName == account.AccountName && a.Name == account.Name).FirstOrDefault();
    }
