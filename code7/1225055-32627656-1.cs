    // Private Members
    private List<Role> rolesCollection;
    private List<TestUser> usersCollection;
    
    // Public Properties
    public IList<Role> RolesCollection
    {
    	get
    	{
    		return this.rolesCollection ?? (this.rolesCollection = new List<Role>(NunitTestDataHelper.GetRoles()));
    	}
    }
    
    public IList<TestUser> UsersCollection
    {
    	get
    	{
    		return this.usersCollection
    			   ?? (this.usersCollection =
    				   new List<TestUser>(
    					   new[]
    					   {
    						   new TestUser { Id = 1, UserName = "Usr1" }.AddRole(this.RolesCollection[0]).AddRole(this.rolesCollection[1]), 
    						   new TestUser { Id = 2, UserName = "Usr2" }.AddRole(this.RolesCollection[0]),
    						   new TestUser { Id = 3, UserName = "User1" }.AddRole(this.rolesCollection[1]),
    						   new TestUser { Id = 4, UserName = "User2" },
    							...
    					   }));
    	}
    }
    
    // Setup DB
    this.Bind<Mock<AppDbContext>>()
    	.ToMethod(
    		m =>
    		NunitTestHelper.GetDbContextMock()
    			.SetupDbContextData(x => x.Roles, this.RolesCollection.AsQueryable())
    			.SetupDbContextData(x => x.Users, this.UsersCollection.AsQueryable()))
    			.InTransientScope();
