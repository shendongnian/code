    public class User 
    {
    	public string UserName { get; set; }
    	public string Email { get; set; }
    
    	//git related properties
    	public string Login { get; set; }
    	public string AvataUrl { get; set; }
    }
    
    //A processor class to model the process of linking a local system user
    //to a remote GitHub User
    public class GitHubLinkProcessor()
    {
    	public int LinkUser(string userName, string email, string gitLogin) 
    	{
            	//first create our local user instance
            	var myUser = new LocalNamespace.User { UserName = userName, Email = email };
    
    		var validator = new UserValidator(myUser);
    		if (!validator.Validate())
    			throw new Exception("Invalid or missing user data!");
    
    		var GitPersistence = new GitHubPersistence();
                    
    		var myGitUser = GitPersistence.FindByUserName(gitLogin);
    		if (myGitUser == null)
    			throw new Exception("User doesnt exist in Git!");
    		
    		myUser.Login = myGitUser.Login;
    		myUser.AvatorUrl = myGitUser.AvatarUrl;
    
    		//assuming your persistence layer is returning the Identity
    		//for this user added to the database
    		var userPersistence = new UserPersistence();
    		return userPersistence.SaveLocalUser(myUser);
    
        	}
    }
    
    public class UserValidator
    {
    	private LocalNamespace.User _user;
    
    	public UserValidator(User user)
    	{
    		this._user = user;
    	}
    
    	public bool Validate()
    	{
    		if (String.IsNullOrEmpty(this._user.UserName) ||
    		    String.IsNullOrEmpty(this._user.Email))
    		{
    			return false;
    		}
    	}
    }
