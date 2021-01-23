    internal static class RoleSeeder
    {
        internal static void Seed(ApplicationDbContext context)
        {
            CreateRole("Admin", "Administrator");
        }
        private static void CreateRole(string name, string description)
        {
            var idManager = new IdentityManager();
            var newRole = new Role
            {
                Name = name,
                Description = description
            };
            if (!idManager.RoleExists(newRole.Name))
                idManager.CreateRole(newRole.Name, newRole.Description);
        }
    }
