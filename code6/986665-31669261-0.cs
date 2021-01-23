    public class ApplicationRoleManager : RoleManager<CustomRole,int>
    {
        public ApplicationRoleManager(IRoleStore<CustomRole,int> roleStore)
            : base(roleStore)
        {
        }
        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
            //return new ApplicationRoleManager(new RoleStore<IdentityRole>(context.Get<ApplicationDbContext>()));
            return new ApplicationRoleManager(new CustomRoleStore(context.Get<ApplicationDbContext>()));
        }
    }
