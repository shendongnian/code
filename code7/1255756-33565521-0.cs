    public class CustomRoleProvider : RoleProvider
    {
        public override bool IsUserInRole(string username, string roleName)
        {
            var userRepository = DependencyResolver.Current.GetService<IGenericRepository<User>>();
            var user = userRepository .AsQueryable().Where(x => x.Username == username && x.Role.Name == roleName); // dbcontext is here disposed...
            return user.Any();
        }
    
        public override string[] GetRolesForUser(string username)
        {
            var userRepository = DependencyResolver.Current.GetService<IGenericRepository<User>>();
            var user = userRepository .AsQueryable().Where(x => x.Username == username).Select(x => x.Role.Name); // dbcontext is here disposed...
            return user.ToArray();
        }
    
        // omitted...
    }
