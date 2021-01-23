	public class VersionContext : DbContext
	{
		public virtual DbSet<DatabaseNumber> DatabaseVersion { get; set; }
		public VersionContext() : base(VersionContextConnection.GetDatabaseConnection(), true)
		{
			System.Data.Entity.Database.SetInitializer<DatabaseContext>(null); 
		}
	}
