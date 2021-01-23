    public class IdentityManager
    {
        public bool RoleExists(string name)
        {
            var rm = new RoleManager<Role>(new RoleStore<Role>(new ApplicationDbContext()));
            return rm.RoleExists(name);
        }
        public bool CreateRole(string name, string description)
        {
            var rm = new RoleManager<Role>(new RoleStore<Role>(new ApplicationDbContext()));
            var newRole = new Role { Description = description, Name = name };
            var idResult = rm.Create(newRole);
            return idResult.Succeeded;
        }
        public bool CreateUser(User user, string password)
        {
            var um = new UserManager<User>(new UserStore<User>(new ApplicationDbContext()));
            um.UserValidator = new UserValidator<User>(um)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = false
            };
            user.UserInfo.ModifiedDate = DateTime.Now;
            user.UserInfo.ModifiedBy = "Migrations";
            user.UserInfo.ValidFrom = DateTime.Now;
            var idResult = um.Create(user, password);
            return idResult.Succeeded;
        }
        public bool AddUserToRole(string userId, string roleName)
        {
            var um = new UserManager<User>(new UserStore<User>(new ApplicationDbContext()));
            um.UserValidator = new UserValidator<User>(um)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = false
            };
            var idResult = um.AddToRole(userId, roleName);
            return idResult.Succeeded;
        }
    }
