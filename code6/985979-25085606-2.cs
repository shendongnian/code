    public class User
    {
    	public ICollection<Account> Accounts {get;set;}
    }
    
    public class Account
    {
    	public ICollection<User> Users {get;set;}
    }
