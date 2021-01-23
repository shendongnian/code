	public class RecreateFromScratch<TContext, TMigrationsConfiguration> : IDatabaseInitializer<TContext>
		where TContext : DbContext
		where TMigrationsConfiguration : DbMigrationsConfiguration<TContext>, new()
	{
		private readonly DbMigrationsConfiguration<TContext> _configuration;
		public RecreateFromScratch()
		{
			_configuration = new TMigrationsConfiguration();
		}
		public void InitializeDatabase(TContext context)
		{
			var migrator = new DbMigrator(_configuration);
			migrator.Update("0");
			migrator.Update();
		}
	}
