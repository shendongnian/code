    public class ApplicationUser : IdentityUser
    {
    	public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
    	{
    		// Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
    		var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
    		// Add custom user claims here
    		return userIdentity;
    	}
    
    	public virtual PersonalInformation PersonalInformation { get; set; }
    }
    
    public class PersonalInformation 
    {
    	[Key, ForeignKey("User")]
    	public string UserId { get;set; }
    	
    	public string FirstName { get; set; }
    	
    	// other fields...
    	
    	public virtual ApplicationUser User { get;set; }
    }
    
    
    // Create user      
    var store = new UserStore<ApplicationUser>(context);
    var manager =  new ApplicationUserManager(store);
    var user = new ApplicationUser() { Email = "email@email.com", UserName = "username", PersonalInformation = new PersonalInformation { FirstName = "FirstName" } };
    manager.Create(user, "Password123!");
    
    // Update user
    var store = new UserStore<ApplicationUser>(context);
    var manager =  new ApplicationUserManager(store);
    var user = manager.Users.FirstOrDefault(u => u.Id == id);
    user.PersonalInformation.FirstName = "EditedName";
    manager.Update(user);
