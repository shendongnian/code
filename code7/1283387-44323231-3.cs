    [ExcludeFromCodeCoverage]
    internal sealed class Configuration : DbMigrationsConfiguration<YourDbContext>
    {
    	public Configuration()
    	{
    		AutomaticMigrationsEnabled = false;
    
    		// Register our custom generator
    		SetSqlGenerator("System.Data.SqlClient", new AddColumnIfNotExistsSqlGenerator());
    	}
    }
