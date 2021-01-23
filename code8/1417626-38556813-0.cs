    public class User
    {
    	public int Id { get; set; }
    	public ICollection<UserAccount> UserAccounts { get; set; }
    }
    
    public class Account
    {
    	public int Id { get; set; }
    	public ICollection<UserAccount> UserAccounts { get; set; }
    }
    
    public class UserAccount
    {
    	public int UserId { get; set; }
    	public int AccountId { get; set; }
    	public int RoleId { get; set; }
    	public User User { get; set; }
    	public Account Account { get; set; }
    	public Role Role { get; set; }
    }
    
    public class Role
    {
    	public int Id { get; set; }
    	public string RoleName { get; set; }
    	public ICollection<UserAccount> UserAccounts { get; set; }
    }
