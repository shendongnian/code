    public class ApplicationRoleManager : RoleManager<ApplicationRole, string>
    {
        public ApplicationRoleManager(IRoleStore<ApplicationRole, string> store)
            : base(store)
        {
        }
        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
    		var dbContext = context.Get<ApplicationDbContext>();
    		var roleStore = new RoleStore<ApplicationRole>(dbContext);
    		var manager = new ApplicationRoleManager(roleStore);
    
    		// Add some roles (e.g. "Administrator") if needed
    		if (!manager.Roles.Any(r => r.Name == "Administrator"))
    		{
    			manager.Create(new ApplicationRole
    			{
    				Name = "Administrator"
    			});
    		}
    		return manager;
        }
    }
