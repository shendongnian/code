    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        private RoleManager<IdentityRole> _roleManager;
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
            _roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());
        }
        public async Task<IList<IdentityRole>> GetModelRolesAsync(string userId)
        {
            IList<string> roleNames = await base.GetRolesAsync(userId);
            var identityRoles = new List<IdentityRole>();
            foreach (var roleName in roleNames)
            {
                IdentityRole role = await _roleManager.FindByNameAsync(roleName);
                identityRoles.Add(role);
            }
            return identityRoles; 
         }      
    }
