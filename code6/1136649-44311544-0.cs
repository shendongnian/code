	[DbConfigurationType(typeof(MyDbContextConfiguration))]
	internal class MyDbContext : DbContext
	{
		public DbSet<MyModel> MyModels { get; set; }
	}
	internal class MyDbContextConfiguration : DbConfiguration
	{
		public MyDbContextConfiguration()
		{
			SetProviderServices("System.Data.SqlClient", SqlProviderServices.Instance);
		}
	}
