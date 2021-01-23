	internal sealed class Configuration : DbMigrationsConfiguration<MyDbContext>
	{
		protected override void Seed(MyDbContext context)
		{
			SeedRoles(context);
		}
		
		private static void SeedRoles(MyDbContext context)
		{
			var manager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
			CreateRoleIfNotExists(manager, "Role1");
			CreateRoleIfNotExists(manager, "Role2");
		}
		
		private static void CreateRoleIfNotExists(RoleManager<IdentityRole> manager, string role)
		{
			if (!manager.RoleExists(role)
			{
				manager.Create(new IdentityRole(role));
			}
		}
	}
