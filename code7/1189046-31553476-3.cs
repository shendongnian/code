    public class CustomDbConfiguration : DbConfiguration
    {
    	public CustomDbConfiguration()
    	{
    		SetMigrationSqlGenerator(SqlProviderServices.ProviderInvariantName,
                () => new CustomSqlGenerator());
    	}
    }
