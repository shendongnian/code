    public class TestUser : User
    {
    	private List<UserRole> roles;
    
    	public TestUser()
    	{
    		this.roles = new List<UserRole>();
    	}
    
    	public override ICollection<UserRole> Roles
    	{
    		get
    		{
    			return this.roles;
    		}
    	}
    
    	public TestUser AddRole(Role role)
    	{
    		this.roles.Add(new UserRole { RoleId = role.Id, UserId = this.Id });
    		return this;
    	}
    }
