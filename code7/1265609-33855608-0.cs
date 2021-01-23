    public class Account {
    }
    public class DepositAccount : Account {
    }
    var accounts = new List<Account>();
    accounts.Add(new Account());
    accounts.Add(new DepositAccount()); //assuming DepositAccount is derived from Account
    var depositA = new DepositAccount();
    accounts.Add(depositA);
